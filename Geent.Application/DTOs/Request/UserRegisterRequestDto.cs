using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.DTOs.Request
{
    public class UserRegisterRequestDto
    {
        public string? Nome { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? TipoUsuario { get; set; }
    }
}
