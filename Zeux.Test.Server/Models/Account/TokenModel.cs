using System.ComponentModel.DataAnnotations;

namespace Zeux.Test.Server.Models.Account
{
    public class TokenModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
