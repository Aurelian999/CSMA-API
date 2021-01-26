using CSMA_API.Data;
using CSMA_API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMA_API.Services
{
    public class PostsService : IPostsService
    {
        private readonly DataContext _dataContext;

        public PostsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreatePostAsync(BlogPost post)
        {
            await _dataContext.Posts.AddAsync(post);
            var createdCount = await _dataContext.SaveChangesAsync();
            return createdCount > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);

            if (post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            var deletedCount = await _dataContext.SaveChangesAsync();
            return deletedCount > 0;
        }

        public async Task<BlogPost> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<List<BlogPost>> GetPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(BlogPost postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var updatedCount = await _dataContext.SaveChangesAsync();

            return updatedCount > 0;
        }

        public async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking().SingleOrDefaultAsync(post => post.Id == postId);

            if (post == null)
            {
                return false;
            }

            return post.AuthorId == userId;
        }
    }
}
