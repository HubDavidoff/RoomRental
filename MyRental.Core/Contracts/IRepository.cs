using MyRental.Core.Model;
using System.Linq;

namespace MyRental.DataAccess.InMemory
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}