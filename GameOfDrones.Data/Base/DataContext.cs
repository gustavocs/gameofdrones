using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameOfDrones.Data.Map;
using GameOfDrones.Models;

namespace GameOfDrones.Data 
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext()
              : base("GameOfDrones")
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new MoveMap());
            //modelBuilder.Configurations.Add(new PlayerMoveMap());
            modelBuilder.Configurations.Add(new RoundMap());
        }

       
    }
}
