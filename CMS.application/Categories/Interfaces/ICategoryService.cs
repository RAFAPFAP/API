using CMS.application.Categories.Models;

namespace CMS.application.Categories.Interfaces
{
    public interface ICategoryService
    {
        public Task<ICollection<CategoryReadDto>> GetAll();
        public Task<CategoryReadDto> Get(int id);
        public Task<CategoryReadDto> Create(CategoryCreationDto category);
        public Task<CategoryReadDto> Update(CategoryReadDto category);
        public Task<bool> Delete(int id);
    }
}
