using IronXL;
using Microsoft.AspNetCore.Http;
using ServiceContracts;
using System.Data;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class ExcelSheetService : IExcelSheetService
    {
        public async Task<bool> UploadExcelFile(IFormFile File)
        {
            try
            {
                if (File.Length > 0)
                {
                    string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, File.FileName), FileMode.Create))
                    {
                        await File.CopyToAsync(fileStream);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }


        public Dictionary<string, List<string?>> ValidateExcelFile(IFormFile File)
        {
            string _Path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "UploadedFiles", File.FileName));
            List<Invoice?> _Invoices = new List<Invoice?>();
            WorkBook workBook = WorkBook.Load(_Path);
            WorkSheet workSheet = workBook.WorkSheets.First();            
            RangeRow[] Raws = workSheet.Rows;
            for (int i = 1; i < Raws.Count(); i++)
            {

                RangeRow Row = Raws[i];
                Invoice _Invoice = new Invoice()
                {
                    DocumentID = Row.ElementAt(1).Text,
                    DocumentDate = Row.ElementAt(2).Text,
                    DocumentType = Row.ElementAt(3).Text,
                    CustomerId = Row.ElementAt(4).Text,
                    CustomerName = Row.ElementAt(5).Text,
                    CustomerType = Row.ElementAt(6).Text,
                    CustomerCountryCode = Row.ElementAt(7).Text,
                    CustomerGovernate = Row.ElementAt(8).Text,
                    CustomerCity = Row.ElementAt(9).Text,
                    CustomerStreet = Row.ElementAt(10).Text,
                    CustomerBuildingNumber = Row.ElementAt(11).Text,
                    ProductCode = Row.ElementAt(12).Text,
                    ProductDescription = Row.ElementAt(13).Text,
                    ProductUnit = Row.ElementAt(14).Text,
                    ProductQuantity = Row.ElementAt(15).IntValue,
                    ProductUnitPrice = Row.ElementAt(16).DoubleValue,
                    ProductDiscountAmount = Row.ElementAt(17).DoubleValue,
                    ProductTaxTypeCode = Row.ElementAt(18).Text,
                    ProductTaxSubTypeCode = Row.ElementAt(19).Text,
                    ProductTaxRatio = Row.ElementAt(20).DoubleValue
                };
                _Invoices.Add(_Invoice);
            }
            Dictionary<string, List<string?>> DocsErrors = new Dictionary<string, List<string?>>();
            ICollection<ValidationResult> Results;
            foreach (Invoice? _Invoice in _Invoices)
            {
                if (!Validate(_Invoice,out Results))
                {

                    List<string?>result=Results.Select(Error => " - "+Error.ErrorMessage).ToList()!;
                    DocsErrors.Add("Document #"+_Invoice!.DocumentID!+ " has the following errors", result);
                }                   
            }          
            
            return DocsErrors;
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj!, new ValidationContext(obj!), results, true);
        }
    }
}
