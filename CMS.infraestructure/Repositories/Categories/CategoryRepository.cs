using CMS.domain.Categories;
using CMS.infraestructure.Data;
using CMS.infraestructure.Repositories.Categories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.infraestructure.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly CMSContext _context;
        public CategoryRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var categoryEntity = await _context.Categories.FirstAsync(x=>x.Id == id);
            _context.Categories.Remove(categoryEntity);
            var isDeleted = await _context.SaveChangesAsync() > 0;
            return isDeleted;

        }

        public async Task<Category> Get(int id)
        {
            var categoryEntity = await _context.Categories.FirstAsync(x => x.Id == id);
            return categoryEntity;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            var categoryEntities = await _context.Categories.ToListAsync();
            return categoryEntities;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
