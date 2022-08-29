using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_chat.Models.DTO
{
    /// <summary>
    /// Post entity DTO
    /// </summary>
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }

        [Required]
        public string? AuthorUsername { get; set; }

        public string? AuthorProfileImage { get; set; }

        [Required]
        public string? Content { get; set; }

        public DateTime timestamp { get; set; }

        public DateTime date { get; set; }

    }
}