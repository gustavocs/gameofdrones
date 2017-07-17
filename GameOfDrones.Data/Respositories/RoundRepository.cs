using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
    public class RoundRepository : RepositoryBase<Round>, IRoundRepository
    {
        public RoundRepository(RoundContext context):base(context)
        {

        }
    }
}
