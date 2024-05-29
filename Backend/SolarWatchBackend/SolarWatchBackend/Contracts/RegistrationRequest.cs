using System.ComponentModel.DataAnnotations;

namespace SolarWatchBackend.Contracts;

public record RegistrationRequest(
    [Required]string Email, 
    [Required]string Username, 
    [Required]string Password);