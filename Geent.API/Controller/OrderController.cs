using Geent.Application.DTOs.Request;
using Geent.Application.DTOs.Response;
using Geent.Application.Interface.Service;
using Geent.Domain.Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Geent.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPostService _postService;
        public OrderController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            try
            {
               var items =  await _postService.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("CreateItem")]
        public async Task<IActionResult> CreateItem(Item post)
        {
            try
            {

              await _postService.CreateItem(post);

              return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem([FromQuery]int id)
        {
            try
            {

                await _postService.DeleteItem(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("GetItemById")]
        public async Task<IActionResult> GetByIdItem([FromQuery] int id)
        {
            try
            {

               var item = await _postService.GetById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {

                var item = await _postService.GetAllOrder();

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("PutEditItem")]
        public async Task<IActionResult> PutEditItem(ItemEditRequestDto itemDto)
        {
            try
            {

                var item = _postService.PutEditItem(itemDto);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
