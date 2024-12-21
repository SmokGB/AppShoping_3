using AppShoping.Entities;

namespace AppShoping.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
        event EventHandler<T?>? ItemAdded; 
        event EventHandler<T?>? ProductDeleted;

        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T item);
        void Remove(T item);
        void Save();

    }
}
