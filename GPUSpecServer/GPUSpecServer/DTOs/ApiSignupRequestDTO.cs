using System.ComponentModel.DataAnnotations;
namespace GPUSpecServer.DTOs
{
    public class ApiSignupRequestDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }
}