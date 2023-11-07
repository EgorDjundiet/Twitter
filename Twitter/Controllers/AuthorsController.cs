using Microsoft.AspNetCore.Mvc;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;
using Twitter.Service.Contracts;

namespace Twitter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _serviceManager.AuthorService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id:guid}", Name = "GetAuthorById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _serviceManager.AuthorService.GetById(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatedAuthor author)
        {
            var authorEntity = await _serviceManager.AuthorService.Create(author);
            return CreatedAtRoute("GetAuthorById", new { id = authorEntity.Id }, authorEntity);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatedAuthor author)
        {
            await _serviceManager.AuthorService.Update(id, author);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceManager.AuthorService.Delete(id);
            return NoContent();
        }
    }
}
