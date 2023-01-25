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
    }
}
