using CMS.application.Posts.Interfaces;
using CMS.application.Posts.Models;
using CMS.domain.Posts;
using CMS.infraestructure.Repositories.Posts.Interfaces;

namespace CMS.application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostReadDto> Create(PostCreationDto post)
        {
            Post postEntity = new Post();
            postEntity.Prioridad = post.Prioridad;
            postEntity.Nombre = post.Nombre;
            postEntity.Descripcion = post.Descripcion;
            postEntity.FechaDePublicacion = post.FechaDePublicacion;
            postEntity.ImageUrl = post.ImageUrl;
            postEntity.Resumen = post.Resumen;
            postEntity.CreatedBy = "API request";
            postEntity.CreatedAt = DateTime.Now;
            postEntity.UpdatedBy = "";
            postEntity.UpdatedAt = DateTime.Now;

            postEntity = await _postRepository.Create(postEntity);

            PostReadDto result = new PostReadDto
            {
                Id = postEntity.Id,
                Nombre = postEntity.Nombre
            };
            return await Task.FromResult(result);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _postRepository.Delete(id);
            return result;
        }

        public async Task<PostReadDto> Get(int id)
        {
            var postEntity = await _postRepository.Get(id);
            var mappedPost = new PostReadDto
            {
                Id = postEntity.Id,
                Resumen = postEntity.Resumen,
                ImageUrl = postEntity.ImageUrl,
                Nombre = postEntity.Nombre,
                Descripcion = postEntity.Descripcion,
                Prioridad = postEntity.Prioridad,
                CategoryIds = postEntity.Categories?.Select(x=>x.Id).ToList(),
                FechaDePublicacion = postEntity.FechaDePublicacion
            };
            return mappedPost;
        }

        public async Task<ICollection<PostReadDto>> GetAll()
        {
            var posts = await _postRepository.GetAll();
            var postsList = posts.Select(x => new PostReadDto {
                Id = x.Id,
                Resumen = x.Resumen,
                ImageUrl = x.ImageUrl,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Prioridad = x.Prioridad,
                CategoryIds = x.Categories?.Select(y => y.Id).ToList(),
                FechaDePublicacion = x.FechaDePublicacion
            }).ToList();
            return postsList;
        }

        public Task<ICollection<PostReadDto>> GetPostByPublishDate(DateTime publishDate)
        {
            throw new NotImplementedException();
        }

        public async Task<PostReadDto> Update(PostReadDto post)
        {
            var postEntity = await _postRepository.Get(post.Id);
            postEntity.Prioridad = post.Prioridad;
            postEntity.Nombre = post.Nombre;
            postEntity.Descripcion = post.Descripcion;
            postEntity.FechaDePublicacion = post.FechaDePublicacion;
            postEntity.ImageUrl = post.ImageUrl;
            postEntity.Resumen = post.Resumen;
            await _postRepository.Update(postEntity);
            return post;
        }
    }
}
