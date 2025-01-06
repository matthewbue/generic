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

        public async Task CreatePost(Post post)
        { 
          await _postRepository.CreatePost(post);
        }
    }
}
