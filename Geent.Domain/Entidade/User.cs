using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Domain.Entidade
{
    public class User
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telefone { get; set; }
        public string? TipoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? FcmToken { get; set; }
        public string? VerificationCode { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerificationCodeExpiration { get; set; }
        public ICollection<Notification>? Notifications { get; set; }

    }
}
