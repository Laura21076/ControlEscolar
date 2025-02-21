using System.ComponentModel.DataAnnotations;

namespace ControlEscolar.Models
{
    public class RegistroRequest
    {
        [Required(ErrorMessage = "La matrícula es obligatoria.")]
        [StringLength(10, ErrorMessage = "La matrícula debe tener máximo 10 caracteres.")]
        public string Matricula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un rol.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un rol válido.")]
        public int IdRol { get; set; }
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }

    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

}
