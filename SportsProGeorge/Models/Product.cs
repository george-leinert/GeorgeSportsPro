using System.ComponentModel.DataAnnotations;

namespace SportsProGeorge.Models
{
    public class Product
    {

        public int ProductID { get; set; }

		[Required(ErrorMessage = "Please enter a product name.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a product code.")]
		public string Code { get; set; } = string.Empty;

		[Required(ErrorMessage = "Please enter a price.")]
		public decimal? Price { get; set; }

		[Required(ErrorMessage = "Please enter release date. ")]
		public DateTime ReleaseDate { get; set; } = DateTime.Now;
	}
}
