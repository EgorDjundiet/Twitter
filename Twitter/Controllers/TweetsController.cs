using Microsoft.AspNetCore.Mvc;
using Twitter.Domain.CreatedModels;
using Twitter.Domain.UpdatedModels;
using Twitter.Service.Contracts;

namespace Twitter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private const string cud = "/api/authors/{authorId:guid}/tweets/";
        private readonly IServiceManager _serviceManager;
        public TweetsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tweets = await _serviceManager.TweetService.GetAll();
            return Ok(tweets);
        }

        [HttpGet("{id:guid}", Name = "GetTweetById")]
        public async Task<IActionResult> GetById(Guid id) 
        {
            var tweet = await _serviceManager.TweetService.GetById(id);
            return Ok(tweet);
        }

        [Route(cud)]
        [HttpPost]
        public async Task<IActionResult> Create(Guid authorId, [FromBody]CreatedTweet tweet)
        {
            var tweetEntity = await _serviceManager.TweetService.Create(authorId, tweet);
            return CreatedAtRoute("GetTweetById", new {id = tweetEntity.Id}, tweetEntity);
        }
        [Route(cud + "{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid authorId, Guid id, [FromBody]UpdatedTweet tweet)
        {
            await _serviceManager.TweetService.Update(authorId, id, tweet);
            return NoContent();
        }
        [Route(cud + "{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid authorId, Guid id)
        {
            await _serviceManager.TweetService.Delete(authorId, id);
            return NoContent();
        }
    }
}
