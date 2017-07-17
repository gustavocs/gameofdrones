using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;

namespace GameOfDrones.Data.Map
{
    public class RoundMap : EntityTypeConfiguration<Round>
    {
        public RoundMap()
        {
            ToTable("Round");

            HasKey(x => x.RoundId);

            HasOptional(x => x.Winner)
                    .WithMany()
                    .HasForeignKey(x => x.WinnerPlayerId);

            HasRequired(x => x.Game)
                .WithMany()
                .HasForeignKey(x => x.GameId);

            HasMany(s => s.Moves)
                    .WithOptional();

        }
    }
}
