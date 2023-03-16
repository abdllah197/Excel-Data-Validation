using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace Excel_Sheet_Validation.Controllers
{
	public class HomeController : Controller
	{
		private readonly IExcelSheetService ExcelSheetService;		
		public HomeController (IExcelSheetService excelSheetService)
		{
			ExcelSheetService = excelSheetService;			
		}
		[Route("/")]
		[HttpGet]
		public IActionResult Index()
		{            
            return View();
		}

        [HttpPost("Home")]
        public async Task<IActionResult> IndexAsync(IFormFile fromFiles)
        {
           /* if (!ModelState.IsValid)
            {
                //get error messages from model state
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }*/
            if (fromFiles != null)
			{
				
				StringBuilder ErrorLog = new StringBuilder();
				if(await ExcelSheetService.UploadExcelFile(fromFiles))
				{
                    Dictionary<string, List<string?>> DocsErrors = ExcelSheetService.ValidateExcelFile(fromFiles);
                    foreach (string DocNum in DocsErrors.Keys)
                    {
                        ErrorLog.AppendLine("\n" + DocNum);
                        foreach (string? Errors in DocsErrors[DocNum])
                        {
                            ErrorLog.AppendLine(Errors);
                        }

                    }
                    ViewBag.Errors = ErrorLog;
                }
				else
                    ViewBag.Errors = "Upload Error";

            }
            
            return View();
        }
    }
}
