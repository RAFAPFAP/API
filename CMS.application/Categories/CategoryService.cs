using CMS.application.Categories.Interfaces;
using CMS.application.Categories.Models;
using CMS.domain.Categories;
using CMS.infraestructure.Repositories.Categories.Interfaces;

namespace CMS.application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoriesRepository;
        public CategoryService(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<CategoryReadDto> Create(CategoryCreationDto category)
        {
            var entity = new Category
            {
                Nombre = category.Nombre
            };
            entity = await _categoriesRepository.Create(entity);
            var mappedEntity = new CategoryReadDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion
            };
            return mappedEntity;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await _categoriesRepository.Delete(id);
            return result;
        }

        public async Task<CategoryReadDto> Get(int id)
        {
            var entity = await _categoriesRepository.Get(id);
            var mappedEntity = new CategoryReadDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                FechaDeCreacion = entity.FechaDeCreacion
            };
            return mappedEntity;
        }

        public async Task<ICollection<CategoryReadDto>> GetAll()
        {
            var entities = await _categoriesRepository.GetAll();
            return entities.Select(x=> new CategoryReadDto {
                Id = x.Id,
                Nombre = x.Nombre,
                FechaDeCreacion = x.FechaDeCreacion
            }).ToList();
        }

        public async Task<CategoryReadDto> Update(CategoryReadDto category)
        {
            var entityToUpdate = await _categoriesRepository.Get(category.Id);


            entityToUpdate.Id = category.Id;
            entityToUpdate.Nombre = category.Nombre;
            entityToUpdate.FechaDeCreacion = category.FechaDeCreacion;

            entityToUpdate = await _categoriesRepository.Update(entityToUpdate);
            var mappedEntity = new CategoryReadDto
            {
                Id = entityToUpdate.Id,
                Nombre = entityToUpdate.Nombre,
                FechaDeCreacion = entityToUpdate.FechaDeCreacion
            };
            return mappedEntity;
        }
    }
}
