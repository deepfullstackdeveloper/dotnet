using System.ComponentModel.DataAnnotations;

namespace BlogApi.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Text is required.")]
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
