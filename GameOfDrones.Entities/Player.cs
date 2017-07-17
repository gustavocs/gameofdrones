using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class Player
    { 
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public byte Number { get; set; }
        public Move LastMove { get; set; }
    }
}