﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Domain.Entidade
{
    public class Role
    {
        public int Id { get; set; }
        public string? TipoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }

}
