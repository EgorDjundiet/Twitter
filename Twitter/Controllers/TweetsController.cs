using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatedTweet tweet)
        {
            var tweetEntity = await _serviceManager.TweetService.Create(tweet);
            return CreatedAtRoute("GetTweetById", new {id = tweetEntity.Id}, tweetEntity);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]UpdatedTweet tweet)
        {
            await _serviceManager.TweetService.Update(id, tweet);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _serviceManager.TweetService.Delete(id);
            return NoContent();
        }
    }
}
