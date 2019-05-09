using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoApp.Core;
using AutoApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AutoDbContext context;

        public PhotoRepository(AutoDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await this.context.Photos.Where(p => p.VehicleId == vehicleId).ToListAsync();
        }
    }
}