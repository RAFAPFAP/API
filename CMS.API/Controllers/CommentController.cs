using CMS.application.Comments.Interfaces;
using CMS.application.Comments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _commentService;
        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;

        }

        /// <summary>
        /// www.test.com/api/comment/Create
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CommentCreationDto comment)
        {
            try
            {
                var commentResult = await _commentService.Create(comment);
                return StatusCode((int)HttpStatusCode.Created, commentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CommentReadDto comment)
        {
            try
            {
                var commentResult = await _commentService.Update(comment);
                return new OkObjectResult(commentResult);
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
                var result = await _commentService.Delete(id);

                return new OkObjectResult(new { deleted = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var comments = await _commentService.GetAll();
                return new OkObjectResult(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var comments = await _commentService.Get(id);
                return new OkObjectResult(comments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}