using System.Threading.Tasks;
using AutoApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Core
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}