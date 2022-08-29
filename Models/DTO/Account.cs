using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_chat.Models.DTO
{
    /// <summary>
    /// Account entity DTO
    /// </summary>
    public class Account
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? ImageUrl { get; set; }

    }
}