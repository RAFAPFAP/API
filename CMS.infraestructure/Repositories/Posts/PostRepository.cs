
using CMS.domain.Posts;
using CMS.infraestructure.Data;
using CMS.infraestructure.Repositories.Posts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.infraestructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly CMSContext _context;
        public PostRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Post> Create(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var postEntity = _context.Posts.First(x => x.Id == id);
            _context.Posts.Remove(postEntity);
            var response = await _context.SaveChangesAsync() > 0;
            return response;
        }

        public async Task<Post> Get(int id)
        {
            var postEntity = await _context.Posts.FirstAsync(x => x.Id == id);
            return postEntity;
        }

        public async Task<ICollection<Post>> GetAll()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<ICollection<Post>> GetPostByPublishDate(DateTime publishDate)
        {

            var filteredPosts = await _context.Posts.Where(x => x.FechaDePublicacion == publishDate).ToListAsync();

            return filteredPosts;
        }

        public async Task<Post> Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
