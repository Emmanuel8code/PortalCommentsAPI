using ApplicationCore.DTOs.CommentDtos;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.MappingExtensions
{
    public static class CommentMappingExtensions
    {
        public static Comment MapCommentReqToComment(this CommentRequestDto commentRequestDto, int postId, int userId)
        {
            if(commentRequestDto == null)
            {
                return null;
            }

            return new Comment
            {
                Title = commentRequestDto.Title,
                Content = commentRequestDto.Content,
                PostId = postId,
                UserId = userId

            };
        }

        public static CommentResponseDto MapCommentToCommentResp(this Comment comment)
        {
            if (comment == null)
            {
                return null;
            }

            return new CommentResponseDto
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
                CreatedAt = comment.CreatedAt,
                UpdateAt = comment.UpdateAt
            };
        }

        public static List<CommentResponseDto> MapToCommentRespList(this IReadOnlyCollection<Comment> commentsList)
        {
            if (commentsList == null)
            {
                return null;
            }

            List<CommentResponseDto> commentsResponseList = new();
            foreach (var comment in commentsList)
            {
                commentsResponseList.Add(comment.MapCommentToCommentResp());
            }

            return commentsResponseList;
        }
    }
}
