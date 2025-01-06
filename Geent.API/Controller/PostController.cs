using Geent.Application.DTOs.Response;
using Geent.Application.Interface.Service;
using Geent.Domain.Entidade;
using Microsoft.AspNetCore.Mvc;

namespace Geent.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
               var filmes = new List<PostResponseDto>
        {
            new PostResponseDto
            {
                Title = "One Pierce",
                Subtitle = "Uma aventura épica",
                LikeTotal = 5,
                CreationDate = new DateTime(2022, 5, 15),
                UserCreation = "João"
            },
            new PostResponseDto
            {
                Title = "O Mistério da Floresta",
                Subtitle = "Um suspense envolvente",
                LikeTotal = 7,
                CreationDate = new DateTime(2021, 3, 10),
                UserCreation = "Maria"
            },
            new PostResponseDto
            {
                Title = "A Última Esperança",
                Subtitle = "Uma história de superação",
                LikeTotal = 6,
                CreationDate = new DateTime(2020, 7, 25),
                UserCreation = "Carlos"
            },
            new PostResponseDto
            {
                Title = "Noites de Verão",
                Subtitle = "Romance sob as estrelas",
                LikeTotal = 5,
                CreationDate = new DateTime(2019, 8, 14),
                UserCreation = "Ana"
            },
            new PostResponseDto
            {
                Title = "A Revolução dos Bichos",
                Subtitle = "Uma alegoria poderosa",
                LikeTotal = 1,
                CreationDate = new DateTime(2023, 1, 5),
                UserCreation = "Pedro"
            },
            new PostResponseDto
            {
                Title = "O Último Samurai",
                Subtitle = "Uma jornada de autodescoberta",
                LikeTotal = 2,
                CreationDate = new DateTime(2022, 11, 20),
                UserCreation = "Fernanda"
            }
        };
                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Post post)
        {
            try
            {

              await _postService.CreatePost(post);

              return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
