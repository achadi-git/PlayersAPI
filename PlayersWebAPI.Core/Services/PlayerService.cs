using PlayersWebAPI.Core.Entities;
using PlayersWebAPI.Core.Exceptions;
using PlayersWebAPI.Core.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersWebAPI.Core.Services
{
    public class PlayerService : IPlayerService
    {
        public readonly IResourceHelper<Player> playersHelper;
        public PlayerService(IResourceHelper<Player> playersHelper)
        {
            this.playersHelper = playersHelper;
        }
        public IList<Player> GetAllPlayers()
        => new List<Player>(playersHelper.GetValues());

        public Player GetPlayerById(int Id)
        {
            var result = playersHelper.GetValue(p => p.id.Equals(Id));
            if (result == null)
                throw new NotFoundException(NotFoundExceptionCode.PlayerNotFound, $"unknow player with id {Id}");

            return result;
        }

        public Statistics GetPlayersStatistics()
        {
            string pays = playersHelper.GetValues()
                 .GroupBy(g => g.country.code)
                 .Select(p => new { country = p.Key, avg = p.Sum(s => s.data.last.Sum()) })
                 .OrderBy(o => o.avg).FirstOrDefault().country;
            double IMC = playersHelper.GetValues().Select(p => (p.data.weight / 100) / Math.Pow(p.data.height, 2)).Average();
            double taille = playersHelper.GetValues().Average(p => p.data.height);
            var result = new Statistics()
            {
                high_ratio_countris = pays,
                averageg_IMC = IMC,
                height_median = taille
            };

            return result;
        }
    }
}
