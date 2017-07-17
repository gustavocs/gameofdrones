using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;

namespace GameOfDrones.Data.Map
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            ToTable("Game");

            HasKey(x => x.GameId);

            HasMany(s => s.Players)
                    .WithRequired(p => p.Game);

            HasMany(s => s.Rounds)
                    .WithRequired(p => p.Game);


        }
    }
}
