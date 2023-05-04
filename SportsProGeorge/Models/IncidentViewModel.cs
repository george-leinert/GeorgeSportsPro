namespace SportsProGeorge.Models
{
	public class IncidentViewModel
	{
        public List<Incident> Incidents { get; set; } = null!;

        public string? FilterSpecify;
        public List<Customer>? Customers { get; set; } = null!;

		public List<Technician>? Technicians { get; set; } = null!;

		public List<Product>? Products { get; set; } = null!;

		public Incident? Incident { get; set; } = null!;

		public string? AddOrEdit { get; set; } = string.Empty;
    }
}
