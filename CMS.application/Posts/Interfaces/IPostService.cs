
using CMS.application.Posts.Models;

namespace CMS.application.Posts.Interfaces
{
    public interface IPostService
    {
        public Task<ICollection<PostReadDto>> GetAll();
        public Task<PostReadDto> Get(int id);
        public Task<PostReadDto> Create(PostCreationDto post);
        public Task<PostReadDto> Update(PostReadDto post);
        public Task<bool> Delete(int id);

        public Task<ICollection<PostReadDto>> GetPostByPublishDate(DateTime publishDate);
    }
}
