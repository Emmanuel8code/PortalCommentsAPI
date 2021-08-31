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
        Task<CommentResponseDto> AddCommentAsync(int userId, int portalId, int postId, CommentRequestDto commentRequestDto);
        Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByPostAsync(int postId);
    }
}
