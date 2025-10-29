using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment
{
    public class UpdateCommentRequestDTO
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Content { get; set; } = string.Empty;
    }
}