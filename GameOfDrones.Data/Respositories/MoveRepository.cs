using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
    public class MoveRepository : RepositoryBase<Move>, IMoveRepository
    {
        public MoveRepository(MoveContext context):base(context)
        {
            
        }
    }
}
