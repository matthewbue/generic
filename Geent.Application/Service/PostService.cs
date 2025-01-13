using Geent.Application.DTOs.Request;
using Geent.Application.Interface.Service;
using Geent.Domain.Entidade;
using Geent.Domain.Interface;
using Geent.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geent.Application.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository configuration)
        {
            _postRepository = configuration;
        }

        public async Task CreateItem(Item post)
        { 
          await _postRepository.CreateItem(post);
        }

        public async Task DeleteItem(int id)
        {
            await _postRepository.DeleteItem(id);
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _postRepository.GetAllItems();
        }

        public async Task<Item> GetById(int id)
        {
            return await _postRepository.GetById(id);
        }


        public async Task<List<Order>> GetAllOrder()
        {
            return await _postRepository.GetAllOrder();
        }

        public Task PutEditItem(Item post)
        {
            throw new NotImplementedException();
        }
    }
}
