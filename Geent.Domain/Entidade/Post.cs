using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Domain.Entidade
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? SubTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public string? UserCreation { get; set; }
        public int LikeTotal { get; set; }
    }
}
