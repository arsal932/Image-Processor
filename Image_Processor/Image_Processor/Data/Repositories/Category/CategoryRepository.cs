using Image_Processor.Data.DBContext;
using Image_Processor.Models.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.Repositories.Category
{
    public class CategoryRepository : IRepository<Categories, int>
    {
        private readonly ImageProcessingDbContext _context;
        public CategoryRepository(ImageProcessingDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int ID)
        {
            Categories category = await _context.Categories.FindAsync(ID);
            _context.Categories.Remove(category);
        }

        public async Task<List<Categories>> GetAll(string TextSearch)
        {
            return await _context
                .Categories
                .Where(c => c.CategoryName.ToLower().Contains(TextSearch.ToLower()) || c.Description.ToLower().Contains(TextSearch.ToLower()))
                .ToListAsync();
        }

        public async Task<Categories> GetById(int ID)
        {
            return await _context.Categories.FindAsync(ID);
        }

        public async Task Insert(Categories Object)
        {
            await _context.Categories.AddAsync(Object);
        }

        public async Task<bool> IsExists(int ID)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryID == ID);
        }

        public void SaveChanges()
        {
             _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Categories Object)
        {
            _context.Categories.Update(Object);
        }
    }
}
