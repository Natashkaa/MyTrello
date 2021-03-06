using MyTrello.Persistance.Contexts;

namespace MyTrello.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;   
        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}