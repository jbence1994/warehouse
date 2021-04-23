namespace Warehouse.Core.Models
{
    public class TechnicianBalanceSummary
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public double Amount { get; set; }
    }
}
