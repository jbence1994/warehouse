using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Models;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnicianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technician>> GetTechnicians()
        {
            return await _context.Technicians.ToListAsync();
        }

        public async Task<IEnumerable<TechnicianPhoto>> GetPhoto(int technicianId)
        {
            return await _context.TechnicianPhotos
                .Where(technicianPhoto => technicianPhoto.TechnicianId == technicianId)
                .ToListAsync();
        }

        public async Task<Technician> GetTechnician(int id)
        {
            return await _context.Technicians.FindAsync(id);
        }

        public async Task Add(Technician technician)
        {
            await _context.Technicians.AddAsync(technician);
        }
    }
}
