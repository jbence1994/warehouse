using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Warehouse.Core.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }
        public ICollection<TechnicianPhoto> Photos { get; set; }
        public ICollection<TechnicianBalance> TechnicianBalances { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Technician()
        {
            Photos = new Collection<TechnicianPhoto>();
            TechnicianBalances = new Collection<TechnicianBalance>();
            Orders = new Collection<Order>();
        }
    }
}
