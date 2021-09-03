using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IServices
{
    public interface ICommentService
    {
        Task<CommentResponseDto> AddCommentAsync(int userId, int postId, CommentRequestDto commentRequestDto);
        Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByPostAsync(int postId);
        Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByWordAsync(string search);
        Task<CommentResponseDto> GetCommentByIdAsync(int commentId);
        Task UpdateCommentContent(int commentId, string content, int userId);
        Task SoftDeleteComment(int commentId);
    }
}
