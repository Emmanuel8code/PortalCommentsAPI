using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.CommentDtos
{
    public class CommentRequestDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(25, ErrorMessage = "Title cannot be longer than 25 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [MaxLength(255, ErrorMessage = "Content cannot be longer than 255 characters")]
        public string Content { get; set; }

        //[Required(ErrorMessage = "Post Id is required")]
        //public int PostId { get; set; }
    }
}
