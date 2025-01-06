using Geent.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Domain.Interface
{
    public interface IPostRepository
    {
        Task CreatePost(Post post);
    }
}
