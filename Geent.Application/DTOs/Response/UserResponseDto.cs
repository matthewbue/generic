using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.DTOs.Response
{
    public class UserResponseDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? TipoUsuario { get; set; }
        public bool FirstAcess { get; set; }

    }
}
