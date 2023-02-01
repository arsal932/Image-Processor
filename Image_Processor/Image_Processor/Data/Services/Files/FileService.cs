using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.File;

namespace Image_Processor.Data.Services.Files
{
    public class FileService: IService<Image_Processor.Models.Entity_Models.Files, int, Models.Response>
    {
        private readonly FilesRepository _filesRepository;
        public FileService(ImageProcessingDbContext context)
        {
            _filesRepository = new FilesRepository(context);
        }
        public async Task Delete(int ID)
        {
            try
            {
                await _filesRepository.Delete(ID);
            }
            catch { }
        }

        public async Task<Models.Response> GetAll(string TextSearch)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _filesRepository.GetAll(TextSearch);
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
                response.Object = await _filesRepository.GetById(ID);
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task Insert(Models.Entity_Models.Files Object)
        {
            try
            {
                await _filesRepository.Insert(Object);
            }
            catch { }
        }

        public async Task<Models.Response> IsExists(int ID)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _filesRepository.IsExists(ID);
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
                _filesRepository.SaveChanges();
            }
            catch { }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _filesRepository.SaveChangesAsync();
            }
            catch { }
        }

        public void Update(Models.Entity_Models.Files Object)
        {
            try
            {
                _filesRepository.Update(Object);
            }
            catch { }
        }
        public List<Models.Entity_Models.Templates> MapMutiple_Entity(List<Models.TemplateViewModel> templateViewModel, DateTime? currentDate)
        {
            var entities = new List<Models.Entity_Models.Templates>();
            foreach (var item in templateViewModel)
                entities.Add(new Models.Entity_Models.Templates() { CategoryID = item.categoryId, TemplateName = item.Name, Description = item.Description, Last_Modified = currentDate, EditorType = item.Type, TemplateID = item.id });
            return entities;
        }
        public Models.Entity_Models.Templates MapSingle_Entity(Models.TemplateViewModel templateViewModel, DateTime? currentDate)
        {
            return new Models.Entity_Models.Templates() { CategoryID = templateViewModel.categoryId, TemplateName = templateViewModel.Name, Description = templateViewModel.Description, EditorType = templateViewModel.Type, TemplateID = templateViewModel.categoryId, Last_Modified = templateViewModel.Last_Modified };
        }
        public List<Models.TemplateViewModel> MapMutiple_DTO(List<Models.Entity_Models.Templates> templates)
        {
            var DTOS = new List<Models.TemplateViewModel>();
            foreach (var item in templates)
                DTOS.Add(new Models.TemplateViewModel() { categoryId = item.CategoryID, Name = item.TemplateName, Description = item.Description, Last_Modified = item.Last_Modified, id = item.TemplateID, Type = item.EditorType });
            return DTOS;
        }
        public Models.TemplateViewModel MapSingle_DTO(Models.Entity_Models.Templates template)
        {
            return new Models.TemplateViewModel() { categoryId = template.CategoryID, Name = template.TemplateName, Description = template.Description, Last_Modified = template.Last_Modified, id = template.TemplateID, Type = template.EditorType };
        }
    }
}
