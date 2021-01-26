using CSMA_API.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMA_API.Services
{
    public interface IPostsService
    {

        Task<List<BlogPost>> GetPostsAsync();

        Task<BlogPost> GetPostByIdAsync(Guid postId);

        Task<bool> CreatePostAsync(BlogPost post);

        Task<bool> UpdatePostAsync(BlogPost postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnsPostAsync(Guid postId, string userId);

    }
}
