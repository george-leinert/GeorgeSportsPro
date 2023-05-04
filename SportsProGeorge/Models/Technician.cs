using System.ComponentModel.DataAnnotations;

namespace SportsProGeorge.Models
{
	public class Technician
	{
		public int TechnicianID { get; set; }

		[Required(ErrorMessage="Please enter a name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Please enter an  email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a phone number")]
		public string PhoneNumber { get; set; }
	}
}
