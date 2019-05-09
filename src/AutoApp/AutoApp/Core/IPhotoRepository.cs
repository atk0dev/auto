using System.Collections.Generic;
using System.Threading.Tasks;
using AutoApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}