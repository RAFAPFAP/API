using CMS.application.Posts.Interfaces;
using CMS.application.Posts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PostController : ControllerBase
    {
        
        private readonly ILogger<PostController> _logger;
        private readonly IPostService _postService;
        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        /// <summary>
        /// www.test.com/api/post/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] PostCreationDto post)
        {
            try
            {
                var createdPost = await _postService.Create(post);
                return StatusCode((int)HttpStatusCode.Created, createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PostReadDto post)
        {
            try
            {
                var updatedPost = await _postService.Update(post);
                return new OkObjectResult(updatedPost);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var result = await _postService.Delete(id);
                return new OkObjectResult(new { deleted = result});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"Could not delete post with {id}");
            }
            
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var posts = await _postService.GetAll();

                return new OkObjectResult(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [AllowAnonymous]
        [HttpGet("GetForViewer")]
        public async Task<IActionResult> GetForViewer()
        {
            try
            {
                var posts = await _postService.GetAll();

                return new OkObjectResult(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var post = await _postService.Get(id);

                return new OkObjectResult(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("publishDate")]
        public async Task<IActionResult> GetByPublishDate([FromQuery] DateTime publishDate)
        {
            try
            {
                var posts = await _postService.GetPostByPublishDate(publishDate);

                return new OkObjectResult(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}