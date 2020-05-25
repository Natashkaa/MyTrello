using System.Threading.Tasks;

namespace MyTrello.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}