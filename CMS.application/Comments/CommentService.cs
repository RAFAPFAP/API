using CMS.application.Comments.Interfaces;
using CMS.application.Comments.Models;
using CMS.domain.Comments;
using CMS.infraestructure.Repositories.Comments.Interfaces;

namespace CMS.application.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentReadDto> Create(CommentCreationDto comment)
        {
            var entity = new Comment
            {
               PostId = comment.PostId,
               FechaPublicacion = comment.FechaPublicacion,
               Comentario = comment.Comentario
            };
            entity = await _commentRepository.Create(entity);
            var mappedEntity = new CommentReadDto
            {
                Id = entity.Id,
                Comentario = entity.Comentario,
                FechaPublicacion = entity.FechaPublicacion,
                PostId = comment.PostId,
                UserId = comment.UserId
                
            };
            return mappedEntity;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _commentRepository.Delete(id);
            return result;
        }

        public async Task<CommentReadDto> Get(int id)
        {
            var entity = await _commentRepository.Get(id);
            var mappedEntity = new CommentReadDto
            {
                Id = entity.Id,
                Comentario = entity.Comentario,
                FechaPublicacion = entity.FechaPublicacion,
                PostId = entity.PostId,
                UserId = entity.UserId
            };
            return mappedEntity;
        }

        public async Task<ICollection<CommentReadDto>> GetAll()
        {
            var entities = await _commentRepository.GetAll();
            return entities.Select(x => new CommentReadDto
            {
                Id = x.Id,
                Comentario = x.Comentario,
                FechaPublicacion = x.FechaPublicacion,
                PostId = x.PostId,
                UserId = x.UserId
            }).ToList();
        }

        public async Task<CommentReadDto> Update(CommentReadDto category)
        {
            var entity = new Comment
            {
                Id = category.Id,
                
            };
            entity = await _commentRepository.Update(entity);
            var mappedEntity = new CommentReadDto
            {
                Id = entity.Id,
                Comentario = entity.Comentario,
                FechaPublicacion = entity.FechaPublicacion,
                PostId = entity.PostId,
                UserId = entity.UserId
            };
            return mappedEntity;
        }
    }
}
