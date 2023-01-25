using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.Category;
using Image_Processor.Models;

namespace Image_Processor.Data.Services.Categories
{
    public class CategoryService : IService<Image_Processor.Models.Entity_Models.Categories, int,Models.Response>
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryService(ImageProcessingDbContext context)
        {
            _categoryRepository = new CategoryRepository(context);
        }
        public async Task Delete(int ID)
        {
            try
            {
                await _categoryRepository.Delete(ID);
            }
            catch { }
        }

        public async Task<Models.Response> GetAll(string TextSearch)
        {
            var response=new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object=await _categoryRepository.GetAll(TextSearch);
                response.Message="Records fetched.";
                response.IsSuccess=true;
            }
            catch { }
            return response;
        }

        public async Task<Models.Response> GetById(int ID)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object =  await _categoryRepository.GetById(ID);
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task Insert(Models.Entity_Models.Categories Object)
        {            
            try
            {
                await _categoryRepository.Insert(Object);                
            }
            catch { }            
        }

        public async Task<Models.Response> IsExists(int ID)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _categoryRepository.IsExists(ID);
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public void SaveChanges()
        {            
            try
            {
                _categoryRepository.SaveChanges();
            }
            catch { }         
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _categoryRepository.SaveChangesAsync();
            }
            catch { }
        }

        public void Update(Models.Entity_Models.Categories Object)
        {
            try
            {
                _categoryRepository.Update(Object);
            }
            catch { }
        }        
    }
}
