using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GameOfDrones.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        void Dispose();
    }
}