using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.MappingExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostService _postService;
        
        public CommentService(ICommentRepository commentRepository, IPostService postService)
        {
            _commentRepository = commentRepository;
            _postService = postService;
        }

        public async Task<CommentResponseDto> AddCommentAsync(int userId, int postId, CommentRequestDto commentRequestDto)
        {
            var comment = commentRequestDto.MapCommentReqToComment(postId, userId);

            await _commentRepository.AddAsync(comment);

            return comment.MapCommentToCommentResp();
        }

        public async Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByPostAsync(int postId)
        {
            var commentsList = await _commentRepository.GetCommentsByPost(postId);
            return commentsList.MapToCommentRespList();
        }

        public async Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByWordAsync(string search, int portalId)
        {
            var commentsList = await _commentRepository.GetCommentsByWord(search, portalId);
            return commentsList.MapToCommentRespList();
        }

        public async Task<CommentResponseDto> GetCommentByIdAsync(int commentId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            if (comment == null)
            {
                throw new EntityNotFoundException("Comment was not found");
            }

            return comment.MapCommentToCommentResp();
        }

        public async Task<CommentResponseDto> UpdateCommentContent(int commentId, string content, int userId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            if(comment == null || (comment.UserId != userId))
            {
                throw new EntityNotFoundException("Comment was not found");
            }

            if((DateTime.Now - comment.CreatedAt).TotalDays > 7)
            {
                throw new ArgumentException("Comment is not editable, days since it was created is greater more 7");
            }

            comment.Content = content;
            await _commentRepository.UpdateAsync(comment);
            
            return comment.MapCommentToCommentResp();
        }

        public async Task SoftDeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetCommentById(commentId);
            if (comment == null)
            {
                throw new EntityNotFoundException("Comment was not  found");
            }

            await _commentRepository.SoftDelete(comment);
        }
    }
}
