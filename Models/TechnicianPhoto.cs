namespace Warehouse.Models
{
    public class TechnicianPhoto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Technician Technician { get; set; }
        public int TechnicianId { get; set; }
    }
}
