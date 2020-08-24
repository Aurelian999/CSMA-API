using CSMA_API.Contracts;
using CSMA_API.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CSMA_API.Controllers.v1
{
    public class PostsController : ControllerBase
    {
        private List<BlogPost> _blogPosts;

        public PostsController()
        {
            _blogPosts = new List<BlogPost>();
            for (int i = 0; i < 3; i++)
            {
                _blogPosts.Add(new BlogPost { Id = i, AuthorId = 1, Content = "some post content", Date = DateTime.Now, Title = "Title" + i });
            }
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_blogPosts);
        }
    }
}
