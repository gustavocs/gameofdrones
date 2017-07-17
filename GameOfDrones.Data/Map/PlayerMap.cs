using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;

namespace GameOfDrones.Data.Map
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");

            HasKey(x => x.PlayerId);

            HasRequired(x => x.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId);

        }
    }
}
