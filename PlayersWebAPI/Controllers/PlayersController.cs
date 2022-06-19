using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayersWebAPI.Core.Entities;
using PlayersWebAPI.Core.Exceptions;
using PlayersWebAPI.Core.Services.Abstractions;

namespace PlayersWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        public readonly IPlayerService playerService;
        public PlayersController(IPlayerService playerService)
        {
           this.playerService = playerService;
        }

        [HttpGet("")]
        public async Task<IList<Player>> GetAllPlayers()
        {
            var result = playerService.GetAllPlayers();
            return await Task.FromResult(result);
        }

        [HttpGet("{player_id}")]
        public async Task<Player> GetPlayer([FromRoute][Required]int player_id)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors)
                                                           .Select(v => v.ErrorMessage + " " + v.Exception));
                throw new UnvalidException(UnvalidCode.MissingFields, $"Invalid data format :{messages}");
            }

            var result = playerService.GetPlayerById(player_id);
            return await Task.FromResult(result);
        }

        [HttpGet("statistics")]
        public async Task<Statistics> GetStatistics()
        {
            var result = playerService.GetPlayersStatistics();
            return await Task.FromResult(result);
        }
    }
}