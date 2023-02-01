using Image_Processor.Data.DBContext;
using Image_Processor.Models.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.Repositories.Template
{
    public class TemplateRepository : IRepository<Templates, int>
    {
        private readonly ImageProcessingDbContext _context;
        public TemplateRepository(ImageProcessingDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int ID)
        {
            Templates category = await _context.Templates.FindAsync(ID);
            _context.Templates.Remove(category);
        }

        public async Task<List<Templates>> GetAll(string TextSearch)
        {
            return await _context
                .Templates
                .Include(c => c.Category)
                .ToListAsync();
        }

        public async Task<Templates> GetById(int ID)
        {
            return await _context.Templates.FindAsync(ID);
        }

        public async Task Insert(Templates Object)
        {
            await _context.Templates.AddAsync(Object);
        }

        public Task<bool> IsExists(int ID)
        {
            return _context.Templates.AnyAsync(c => c.TemplateID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Templates Object)
        {
            _context.Templates.Update(Object);
        }
    }
}
