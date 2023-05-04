using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsProGeorge.Models
{
	public class Incident
	{
		public int IncidentID { get; set; }


		[Required(ErrorMessage = "Please enter a title.")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a description")]
		public string Description { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please select a customer. ")]
		public int? CustomerID { get; set; }

		[ValidateNever]
		public Customer Customer { get; set; } = null!;

		[Required(ErrorMessage = "Please select a product.")]
		public int? ProductID { get; set; }

		[ValidateNever]
		public Product Product { get; set; } = null!;


		[Required(ErrorMessage = "Please select a technician.")]
		public int? TechnicianID { get; set; }

		[ValidateNever]
		public Technician Technician { get; set; } = null!;

		[Required(ErrorMessage = "Please select a date opened.")]
		public DateTime? DateOpened { get; set; } = null;

        public DateTime? DateClosed { get; set; } = null;

    }
}
