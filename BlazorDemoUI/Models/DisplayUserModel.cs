using System.ComponentModel.DataAnnotations;

namespace BlazorDemoUI.Models
{
    public class DisplayUserModel
    {
        [Required, 
            EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required,
            StringLength(15, ErrorMessage = "Username too long (15 characters max)"),
            MinLength(5, ErrorMessage = "Username too short (5 characters min")]
        public string Username { get; set; } = string.Empty;

        [Required, 
            StringLength(100, ErrorMessage = "Password too long (100 characters max)"),
            MinLength(6, ErrorMessage = "Password too short (6 characters min)")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public int RoleId { get; set; } = 1;

        [Required, 
            DateOfBirth(MinAge = 0, MaxAge = 150, ErrorMessage = "Are you a time traveler?")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Please Confirm your Credentials")]
        public bool IsConfirmed { get; set; } = false;
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
                return false;

            return (val.AddYears(MaxAge) > DateTime.Now);
        }

        public string? GetErrorMessage()
        {
            return ErrorMessage;
        }
    }
}
