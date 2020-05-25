using System.Threading.Tasks;
using MyTrello.Domain.Repositories;
using MyTrello.Persistance.Contexts;

namespace MyTrello.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}