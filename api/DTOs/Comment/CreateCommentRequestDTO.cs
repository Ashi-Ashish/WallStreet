using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace api.DTOs.Comment
{
    public class CreateCommentRequestDTO
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Content { get; set; } = string.Empty;
    }
}