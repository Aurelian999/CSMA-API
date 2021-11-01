using CSMA_API.Contracts;
using CSMA_API.Controllers.v1.Requests;
using CSMA_API.Controllers.v1.Responses;
using CSMA_API.Domain;
using CSMA_API.Extensions;
using CSMA_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSMA_API.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                AuthorId = HttpContext.GetUserId(),
                Date = DateTime.UtcNow,
                Title = postRequest.Title,
                Tags = postRequest.Tags,
                Content = postRequest.Content
            };

            await _postsService.CreatePostAsync(post);
            var baseUrl = new Uri($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}");
            var locationUri = new Uri(baseUrl, ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString()));

            var response = new BlogPostResponse
            {
                Id = post.Id,
                AuthorId = HttpContext.GetUserId(),
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

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid postId, [FromBody]UpdateBlogPostRequest updateBlogPostRequest)
        {
            var userOwnsPost = await _postsService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
            {
                return BadRequest(new { error = "You cand only edit your own posts." });
            }

            var post = await _postsService.GetPostByIdAsync(postId);
            post.Title = updateBlogPostRequest.Title;
            post.Content = updateBlogPostRequest.Content;
            //post.Tags = updateBlogPostRequest.Tags;

            var updated = await _postsService.UpdatePostAsync(post);

            if (updated)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid postId)
        {
            var userOwnsPost = await _postsService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
            {
                return BadRequest(new { error = "You cand only remove your own posts." });
            }

            var deleted = await _postsService.DeletePostAsync(postId);

            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }


    }
}