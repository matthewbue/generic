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
        Task CreateItem(Item post);

        Task DeleteItem(int id);
        Task<Item> GetById(int id);
        Task<List<Item>> GetAllItems();

        Task<List<Order>> GetAllOrder();
    }
}
