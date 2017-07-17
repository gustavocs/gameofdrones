using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public Player[] Players { get; set; }
        public Round[] Rounds { get; set; }
    }
}