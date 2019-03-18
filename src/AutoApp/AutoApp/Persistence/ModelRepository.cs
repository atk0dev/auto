using System.Threading.Tasks;
using AutoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public class ModelRepository : IModelRepository
    {
        private readonly AutoDbContext context;
        public ModelRepository(AutoDbContext context)
        {
            this.context = context;
        }
        public async Task<Model> GetModel(int id)
        {
            return await this.context.Models.FindAsync(id);
        }
    }
}