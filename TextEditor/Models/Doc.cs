using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextEditor.Models
{
    public class Doc
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)] // Optional: Limit title length
        public string Title { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty; // Always initialize

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }
}
