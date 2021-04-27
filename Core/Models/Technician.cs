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
        public ICollection<TechnicianPhoto> Photos { get; set; }
        public TechnicianBalanceSummary Balance { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public Technician()
        {
            Photos = new Collection<TechnicianPhoto>();
            Sales = new Collection<Sale>();
        }
    }
}
