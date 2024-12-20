using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Domain.Entidade
{
    public class Notification
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string? Mensagem { get; set; }
        public string? Tipo { get; set; }
        public string? Status { get; set; }
        public DateTime DataEnvio { get; set; }
        public User? User { get; set; }
    }

}
