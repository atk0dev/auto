namespace AutoApp.Persistence
{
    using System.Threading.Tasks;
    using AutoApp.Core;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoDbContext context;
        public UnitOfWork(AutoDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}