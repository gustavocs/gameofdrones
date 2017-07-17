using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GameOfDrones.Models
{
    public class Player
    { 
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public byte Number { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public bool Winner { get; set; }

    }
}