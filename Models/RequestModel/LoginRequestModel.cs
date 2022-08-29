using System.ComponentModel.DataAnnotations;

namespace music_chat.Models.RequestModel
{

    /// <summary>
    /// Login request form model
    /// </summary>
    public class LoginRequestModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}