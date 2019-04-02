using System.Threading.Tasks;
using AutoApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Core
{
    public interface IModelRepository
    {
        Task<Model> GetModel(int id);
    }
}