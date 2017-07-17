using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class GameConfig
    {
        public int WinLimit { get; set; }
        public Move[] Moves { get; set; }
    }
}