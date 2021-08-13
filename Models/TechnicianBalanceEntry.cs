using System;

namespace Warehouse.Models
{
    public class TechnicianBalanceEntry
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
