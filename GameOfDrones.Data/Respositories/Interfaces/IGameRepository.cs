using GameOfDrones.Models;

namespace GameOfDrones.Data
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Game GetResult(int gameId);
    }
}