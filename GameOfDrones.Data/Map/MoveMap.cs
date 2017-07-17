using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;

namespace GameOfDrones.Data.Map
{
    public class MoveMap : EntityTypeConfiguration<Move>
    {
        public MoveMap()
        {
            ToTable("Move");

            HasKey(x => x.MoveId);

            HasOptional(e => e.Kills)
                .WithMany()
                .HasForeignKey(x => x.KillsMoveId);

        }
    }
}
