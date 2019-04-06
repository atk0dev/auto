using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoApp.Core;
using AutoApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using AutoApp.Extensions;
using System.Linq.Expressions;
using System;

namespace AutoApp.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AutoDbContext context;
        public VehicleRepository(AutoDbContext context)
        {
            this.context = context;
        }

        public async Task<QueryResult<Vehicle>> GetVehicles(VehicleQuery queryObj)
        {
            var result = new QueryResult<Vehicle>();

            var query = context.Vehicles
              .Include(v => v.Model)
                .ThenInclude(m => m.Make)
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName
            };
            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
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