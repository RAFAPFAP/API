using CMS.application.Comments.Models;

namespace CMS.application.Comments.Interfaces
{
    public interface ICommentService
    {
        public Task<ICollection<CommentReadDto>> GetAll();
        public Task<CommentReadDto> Get(int id);
        public Task<CommentReadDto> Create(CommentCreationDto post);
        public Task<CommentReadDto> Update(CommentReadDto post);
        public Task<bool> Delete(int id);
    }
}
