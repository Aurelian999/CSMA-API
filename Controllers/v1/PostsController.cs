using CSMA_API.Contracts;
using CSMA_API.Controllers.v1.Requests;
using CSMA_API.Controllers.v1.Responses;
using CSMA_API.Domain;
using CSMA_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSMA_API.Controllers.v1
{
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBlogPostRequest postRequest)
        {
            var post = new BlogPost
            {
                Id = Guid.NewGuid(),
                AuthorId = postRequest.AuthorId,
                Date = DateTime.UtcNow,
                Title = postRequest.Title,
                //Tags = postRequest.Tags,
                Content = postRequest.Content
            };

            await _postsService.CreatePostAsync(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new BlogPostResponse
            {
                Id = post.Id,
                AuthorId = postRequest.AuthorId,
                Date = DateTime.UtcNow,
                Title = postRequest.Title,
                Tags = postRequest.Tags,
                Content = postRequest.Content
            };

            return Created(locationUri, response);

        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postsService.GetPostsAsync());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postsService.GetPostByIdAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}