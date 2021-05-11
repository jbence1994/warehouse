using System;
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
        public ICollection<TechnicianBalanceEntry> BalanceEntries { get; set; }
        public ICollection<TechnicianPhoto> Photos { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Technician()
        {
            BalanceEntries = new Collection<TechnicianBalanceEntry>();
            Photos = new Collection<TechnicianPhoto>();
            Orders = new Collection<Order>();
        }

        public void DecrementBalance(double amount)
        {
            Balance -= amount;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void AddBalanceEntry()
        {
            BalanceEntries.Add(new TechnicianBalanceEntry
            {
                Amount = Balance,
                CreatedAt = DateTime.Now
            });
        }

        public void AddPhoto(TechnicianPhoto technicianPhoto)
        {
            Photos.Add(technicianPhoto);
        }
    }
}
