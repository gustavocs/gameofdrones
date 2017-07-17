using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfDrones.Models;
using GameOfDrones.Data;

namespace GameOfDrones.Services
{
    public class RoundService : ServiceBase<Round>, IRoundService
    {
        public RoundService(RoundRepository repository) : base(repository) { }
    }
}
