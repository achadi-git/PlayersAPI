using PlayersWebAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayersWebAPI.Core.Services.Abstractions
{
    public interface IPlayerService
    {
        IList<Player> GetAllPlayers();
        Player GetPlayerById(int Id);
        Statistics GetPlayersStatistics();
    }
}
