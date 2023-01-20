using Image_Processor.Data.DBContext;
using Image_Processor.Models.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace Image_Processor.Data.Repositories.File
{
    public class FilesRepository:IRepository<Files,int>
    {
        private readonly ImageProcessingDbContext _context;
        public FilesRepository(ImageProcessingDbContext context)
        {
            this._context = context;
        }
        public async Task Delete(int ID)
        {
            Files category = await _context.Files.FindAsync(ID);
            _context.Files.Remove(category);
        }

        public async Task<List<Files>> GetAll(string TextSearch)
        {
            return await _context
                .Files
                .Where(c => c.DisplayName.ToLower().Contains(TextSearch.ToLower()))
                .ToListAsync();
        }

        public async Task<Files> GetById(int ID)
        {
            return await _context.Files.FindAsync(ID);
        }

        public async Task Insert(Files Object)
        {
            await _context.Files.AddAsync(Object);
        }

        public Task<bool> IsExists(int ID)
        {
            return _context.Files.AnyAsync(c => c.FileID == ID);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Files Object)
        {
            _context.Files.Update(Object);
        }
    }
}
