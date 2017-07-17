using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class GameConfig
    {
        public static byte WIN_LIMIT = 3;

        public byte WinLimit { get { return WIN_LIMIT;  } }
        public ICollection<Move> Moves { get; set; }
    }
}