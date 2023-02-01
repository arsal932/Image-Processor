using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.Template;

namespace Image_Processor.Data.Services.Templates
{
    public class TemplateService : IService<Image_Processor.Models.TemplateViewModel, int, Models.Response>
    {
        private readonly TemplateRepository _templateRepository;
        public TemplateService(ImageProcessingDbContext context)
        {
            _templateRepository = new TemplateRepository(context);
        }
        public async Task Delete(int ID)
        {
            try
            {
                await _templateRepository.Delete(ID);
            }
            catch { }
        }

        public async Task<Models.Response> GetAll(string TextSearch)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = MapMutiple_DTO(await _templateRepository.GetAll(TextSearch));
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
                response.Object = MapSingle_DTO(await _templateRepository.GetById(ID));
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task Insert(Image_Processor.Models.TemplateViewModel Object)
        {
            try
            {
                await _templateRepository.Insert(MapSingle_Entity(Object, null));
            }
            catch (Exception ex) { }
        }

        public async Task<Models.Response> IsExists(int ID)
        {
            var response = new Models.Response() { IsSuccess = false, Object = null, Message = "" };
            try
            {
                response.Object = await _templateRepository.IsExists(ID);
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
                _templateRepository.SaveChanges();
            }
            catch { }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _templateRepository.SaveChangesAsync();
            }
            catch { }
        }

        public void Update(Image_Processor.Models.TemplateViewModel Object)
        {
            try
            {
                _templateRepository.Update(MapSingle_Entity(Object, DateTime.Now));
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
            return new Models.Entity_Models.Templates() { CategoryID = templateViewModel.categoryId, TemplateName = templateViewModel.Name, Description = templateViewModel.Description, EditorType = templateViewModel.Type, TemplateID = templateViewModel.id, Last_Modified = templateViewModel.Last_Modified };
        }
        public List<Models.TemplateViewModel> MapMutiple_DTO(List<Models.Entity_Models.Templates> templates)
        {
            var DTOS = new List<Models.TemplateViewModel>();
            foreach (var item in templates)
                DTOS.Add(new Models.TemplateViewModel() { Category = item.Category.CategoryName, categoryId = item.CategoryID, Name = item.TemplateName, Description = item.Description, Last_Modified = item.Last_Modified, id = item.TemplateID, Type = item.EditorType });
            return DTOS;
        }
        public Models.TemplateViewModel MapSingle_DTO(Models.Entity_Models.Templates template)
        {
            return new Models.TemplateViewModel() { Category = template.Category.CategoryName, categoryId = template.CategoryID, Name = template.TemplateName, Description = template.Description, Last_Modified = template.Last_Modified, id = template.TemplateID, Type = template.EditorType };
        }
    }
}

