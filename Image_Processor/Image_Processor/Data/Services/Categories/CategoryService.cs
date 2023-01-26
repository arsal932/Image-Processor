using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.Category;
using Image_Processor.Models;

namespace Image_Processor.Data.Services.Categories
{
    public class CategoryService : IService<Image_Processor.Models.CategoryViewModel, int, Models.Response>
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
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = MapMutiple_DTO(await _categoryRepository.GetAll(TextSearch));
                response.Message = "Records fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task<Models.Response> GetById(int ID)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _categoryRepository.GetById(ID);
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task Insert(Models.CategoryViewModel Object)
        {
            try
            {
                await _categoryRepository.Insert(MapSingle_Entity(Object, DateTime.Now));
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

        public void Update(Models.CategoryViewModel Object)
        {
            try
            {
                _categoryRepository.Update(MapSingle_Entity(Object, DateTime.Now));
            }
            catch { }
        }
        public List<Models.Entity_Models.Categories> MapMutiple_Entity(List<Models.CategoryViewModel> categoryViewModel, DateTime? currentDate)
        {
            var entities = new List<Models.Entity_Models.Categories>();
            foreach (var item in categoryViewModel)
                entities.Add(new Models.Entity_Models.Categories() { CategoryID = item.ID, CategoryName = item.Name, Description = item.Description, Last_Modified = currentDate });
            return entities;
        }
        public Models.Entity_Models.Categories MapSingle_Entity(Models.CategoryViewModel categoryViewModel, DateTime? currentDate)
        {
            return new Models.Entity_Models.Categories() { CategoryID = categoryViewModel.ID, CategoryName = categoryViewModel.Name, Description = categoryViewModel.Description, Last_Modified = currentDate };
        }
        public List<Models.CategoryViewModel> MapMutiple_DTO(List<Models.Entity_Models.Categories> categories)
        {
            var DTOS = new List<Models.CategoryViewModel>();
            foreach (var item in categories)
                DTOS.Add(new Models.CategoryViewModel() { ID = item.CategoryID, Name = item.CategoryName, Description = item.Description, Last_Modified = item.Last_Modified });
            return DTOS;
        }
        public Models.CategoryViewModel MapSingle_DTO(Models.Entity_Models.Categories category)
        {
            return new Models.CategoryViewModel() { ID = category.CategoryID, Name = category.CategoryName, Description = category.Description, Last_Modified = category.Last_Modified };
        }
    }
}
