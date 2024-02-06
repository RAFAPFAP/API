using CMS.domain.Comments;

namespace CMS.infraestructure.Repositories.Comments.Interfaces
{
    public interface ICommentRepository
    {
        public Task<ICollection<Comment>> GetAll();
        public Task<Comment> Get(int id);
        public Task<Comment> Create(Comment comment);
        public Task<Comment> Update(Comment comment);
        public Task<bool> Delete(int id);

    }
}
