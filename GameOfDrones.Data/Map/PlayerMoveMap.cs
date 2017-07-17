using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;

namespace GameOfDrones.Data
{
    public class PlayerMoveMap : EntityTypeConfiguration<PlayerMove>
    {
        public PlayerMoveMap()
        {
            HasKey(x => x.PlayerMoveId);

            HasOptional(x => x.Move)
                      .WithMany()
                      .HasForeignKey(x => x.MoveId); 
                
            HasOptional(x => x.Player)
                      .WithMany()
                      .HasForeignKey(x => x.PlayerMoveId);


        }
    }
}
