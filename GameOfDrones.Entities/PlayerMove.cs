using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfDrones.Models
{
    public class PlayerMove : Move
    { 
        public Player Player { get; set; }
    }
}