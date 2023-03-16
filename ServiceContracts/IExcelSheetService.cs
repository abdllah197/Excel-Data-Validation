using Microsoft.AspNetCore.Http;

namespace ServiceContracts
{
	public interface IExcelSheetService
	{
        public Dictionary<string, List<string?>> ValidateExcelFile(IFormFile File);
        public Task<bool>UploadExcelFile(IFormFile File);

    }
}