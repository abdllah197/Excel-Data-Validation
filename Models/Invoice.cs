using Models.CustomValidation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
	public class Invoice
	{
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document ID")]
        public string? DocumentID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document Date")]
        [DateValidation]
        public string? DocumentDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document Type")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer ID")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be a valid integer")]

        public string? CustomerId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Name")]        
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Type")]
        [ValuesValidation("Person","Company",ErrorMessage ="{0} must be {1} or {2} only")]
        public string? CustomerType { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Country Code")]
        public string? CustomerCountryCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Governate")]
        public string? CustomerGovernate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer City")]
        public string? CustomerCity { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = " Customer Street")]
        public string? CustomerStreet { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Customer Building Number")]
        public string? CustomerBuildingNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Code")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Description")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Unit")]
        public string? ProductUnit { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} must be greater than 0")]
        public double ProductQuantity { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Unit Price")]
        public double ProductUnitPrice { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Discount Amount")]
        public double ProductDiscountAmount { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Tax Type Code")]
        [ValuesValidation("T1", "T2","T3","T4", ErrorMessage = "{0} must be {1} or {2} or {3} or {4} only")]
        public string? ProductTaxTypeCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Tax Sub Type Code")]
        [ValuesValidation("V001", "V002", "V003", "V004", ErrorMessage = "{0} must be {1} or {2} or {3} or {4}")]
        public string? ProductTaxSubTypeCode { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Product Tax Ratio")]
        public double ProductTaxRatio { get; set; }
        
	}
}