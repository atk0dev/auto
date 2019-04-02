using System.Threading.Tasks;

namespace AutoApp.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}