using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Entities;
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

        public async Task<CommentResponseDto> AddCommentAsync(int userId, int portalId, int postId, CommentRequestDto commentRequestDto)
        {
            if (!(_postService.PostBelongsToPortal(postId, portalId))) //Ojo, creo que esta demas el postexist si comparo el postbelongs ya me daria falso. A parte ver filtros para llevar este codigo afuera en el controlador
            {
                throw new ArgumentException("Post Id Invalid");
            }

            var comment = commentRequestDto.MapCommentReqToComment(postId);

            await _commentRepository.AddAsync(comment);

            return comment.MapCommentToCommentResp();
        }

        public async Task<IReadOnlyCollection<CommentResponseDto>> GetCommentsByPostAsync(int postId)
        {
            //if (!(_postService.PostBelongsToPortal(postId, portalId))) //Ojo, creo que esta demas el postexist si comparo el postbelongs ya me daria falso. A parte ver filtros para llevar este codigo afuera en el controlador
            //{
            //    throw new ArgumentException("Post Id Invalid");
            //}

            var commentsList = await _commentRepository.GetCommentsByPost(postId);
            List<CommentResponseDto> commentsResponseList = new();
            foreach (var comment in commentsList)
            {
                commentsResponseList.Add(comment.MapCommentToCommentResp());
            }

            return commentsResponseList;
        }
    }
}
