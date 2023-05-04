using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsProGeorge.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }

		[Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

		//[Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a city")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter an address")]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a state")]
        [StringLength(50)]
        public string State { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a zip code")]
        public int? ZipCode { get; set; }

		[Required(ErrorMessage = "Please enter a country")]
		public int CountryId { get; set; }

		[ValidateNever]
		public Country Country { get; set; } = null!;

		//[Required(ErrorMessage = "Please enter a phone number")]
		//[RegularExpression(@"^\(\d{3}\)\s\d{3}-\d{4}")]
		public string PhoneNumber { get; set; } = string.Empty;

	}
}
