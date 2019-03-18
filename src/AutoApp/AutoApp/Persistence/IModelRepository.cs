using System.Threading.Tasks;
using AutoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Persistence
{
    public interface IModelRepository
    {
        Task<Model> GetModel(int id);
    }
}