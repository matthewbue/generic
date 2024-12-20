using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.DTOs.Request
{
    public class VerifyUserRequestDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
