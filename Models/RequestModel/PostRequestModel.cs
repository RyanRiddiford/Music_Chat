using System.ComponentModel.DataAnnotations;

namespace music_chat.Models.RequestModel
{

    /// <summary>
    /// Post request form model
    /// </summary>
    public class PostRequestModel
    {
        [Required]
        public string? Content { get; set; }
    }
}