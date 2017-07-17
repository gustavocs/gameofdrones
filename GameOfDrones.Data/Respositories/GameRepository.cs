using GameOfDrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(GameContext context):base(context)
        {

        }

        public Game GetResult(int gameId)
        {
            Game game = Db.Set<Game>().Find(gameId);

            game.Rounds = Db.Set<Round>().Where(r => r.GameId == gameId).ToList();
            game.Players = Db.Set<Player>().Where(r => r.GameId == gameId).ToList();

            return game;
        }
    }
}
