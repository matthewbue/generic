using Geent.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.Interface.Service
{
    public interface IPostService
    {
       Task CreateItem(Item post);
        Task<List<Item>> GetAllItems();
        Task DeleteItem(int id);
        Task<Item> GetById(int id);
        Task PutEditItem(Item post);
 

    }
}
