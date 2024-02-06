using CMS.domain.Posts;

namespace CMS.infraestructure.Repositories.Posts.Interfaces
{
    public interface IPostRepository
    {
        public Task<ICollection<Post>> GetAll();
        public Task<Post> Get(int id);
        public Task<Post> Create(Post post);
        public Task<Post> Update(Post post);
        public Task<bool> Delete(int id);

        public Task<ICollection<Post>> GetPostByPublishDate(DateTime publishDate);
    }
}
