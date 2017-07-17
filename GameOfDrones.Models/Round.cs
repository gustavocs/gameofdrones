using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class Round
    {
        public int RoundId { get; set; }

        public int? WinnerPlayerId { get; set; }
        public Player Winner { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public ICollection<PlayerMove> Moves { get; set; }

    }
}