using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Comment>> GetCommentsByPost(int postId)
        {
           return await (from c in _dbContext.Comments
                          where c.PostId == postId && c.DeletedAt == null
                          orderby c.CreatedAt
                          select c).ToListAsync();
        }

        public async Task<IReadOnlyList<Comment>> GetCommentsByWord(string search)
        {
            var queryable = _dbContext.Comments.AsQueryable();
            
            if(search != null)
            {
                queryable = queryable.Where(x => x.DeletedAt == null && x.Content.Contains(search));
            }

            return await queryable.OrderBy(c => c.CreatedAt).ThenBy(c => c.UserId).ThenBy(c => c.PostId)
                .ToListAsync();
        }
    }
}
