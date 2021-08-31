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
            return await _dbContext.Comments
                .Where(c => c.PostId == postId && c.DeletedAt == null)
                .OrderBy(c => c.CreatedAt)
                .ToListAsync(); 
        }
    }
}
