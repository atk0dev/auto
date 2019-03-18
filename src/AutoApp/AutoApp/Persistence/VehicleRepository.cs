using System.Threading.Tasks;
using AutoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoDbContext context;
        public VehicleRepository(AutoDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await this.context.Vehicles.FindAsync(id);
            }

            return await this.context.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Add(Vehicle vehicle)
        {
            this.context.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            this.context.Remove(vehicle);
        }
    }
}