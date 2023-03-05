using System.ComponentModel.DataAnnotations;

namespace Assignment_Asp.NET1.Models.Forms
{
    public class RegisterForm
    {
        public string? ReturnUrl { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? Company { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public bool TermsAndAggreements { get; set; }

    }
}
