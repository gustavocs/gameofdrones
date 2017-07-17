using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class Move
    { 
        public int MoveId { get; set; }
        public string Name { get; set; }
        public Move Kills { get; set; }
    }
}