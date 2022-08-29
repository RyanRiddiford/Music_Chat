using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_chat.Models.DTO
{
    /// <summary>
    /// Login entity DTO
    /// </summary>
    public class Login
    {

        [ForeignKey("Account"), Required]
        public Guid AccountId { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

    }
}