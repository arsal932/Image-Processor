using Image_Processor.Data.DBContext;
using Image_Processor.Data.Repositories.Template;

namespace Image_Processor.Data.Services.Templates
{
    public class TemplateService: IService<Image_Processor.Models.Entity_Models.Templates, int, Models.Response>
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
                response.Object = await _templateRepository.GetAll(TextSearch);
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
                response.Object = await _templateRepository.GetById(ID);
                response.Message = "Record fetched.";
                response.IsSuccess = true;
            }
            catch { }
            return response;
        }

        public async Task Insert(Models.Entity_Models.Templates Object)
        {
            try
            {
                await _templateRepository.Insert(Object);
            }
            catch { }
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

        public void Update(Models.Entity_Models.Templates Object)
        {
            try
            {
                _templateRepository.Update(Object);
            }
            catch { }
        }
    }
}

