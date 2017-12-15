using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
