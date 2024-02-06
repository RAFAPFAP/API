using CMS.domain.Categories;

namespace CMS.infraestructure.Repositories.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<ICollection<Category>> GetAll();
        public Task<Category> Get(int id);
        public Task<Category> Create(Category category);
        public Task<Category> Update(Category category);
        public Task<bool> Delete(int id);
    }
}
