using System.ComponentModel.DataAnnotations;

namespace Assignment_Asp.NET1.Models.Forms
{
    public class LoginForm
    {
        public string? ReturnUrl { get; set; }

        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!; 
        public bool KeepMeLoggedIn { get; set; }    
    }
}
