using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.DTOs.Request
{
    public class ItemEditRequestDto
    {
        public int Id { get; set; } // Identificador único do item
        public string? Name { get; set; } // Nome do item
        public string? Description { get; set; } // Descrição do item
        public decimal? Price { get; set; } // Preço unitário do item (nullable)
        public string? Category { get; set; } // Categoria do item
    }
}
