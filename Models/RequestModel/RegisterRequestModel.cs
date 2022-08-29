using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace music_chat.Models.RequestModel
{
    /// <summary>
    /// Register request form model
    /// </summary>
    public class RegisterRequestModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required, DisplayName("Upload Profile Image")]
        public IFormFile? ImageUrl { get; set; }

    }
}