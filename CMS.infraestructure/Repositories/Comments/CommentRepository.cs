using CMS.domain.Comments;
using CMS.infraestructure.Data;
using CMS.infraestructure.Repositories.Comments.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.infraestructure.Repositories.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CMSContext _context;

        public CommentRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Comment> Create(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _context.Comments.First(x => x.Id == id);
            _context.Comments.Remove(entity);
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<Comment> Get(int id)
        {
            var comment = await _context.Comments.FirstAsync(x => x.Id == id);
            return comment;
        }

        public async Task<ICollection<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> Update(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
    }
}
