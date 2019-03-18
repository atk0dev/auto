using System.Threading.Tasks;

namespace AutoApp.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}