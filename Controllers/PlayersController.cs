using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IRepository _repository;
        public PlayersController(ILogger<PlayersController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        [Route("getbyName/{name}")]
        public async Task<Player> Get(string name)
        {
            return await _repository.Get(name);
        }
        [HttpGet]
        [Route("GetallFromplayer/{namer}")]
        public async Task<List<Player>> GetAllFromPlayer(string namer)
        {

            return await _repository.GetAllFromPlayer(namer);
        }


        [HttpGet]
        public async Task<Player[]> GetAll()
        {
            return await _repository.GetAll();
        }
        // [HttpGet]
        // [Route("Minscore/{score:int:min(0)}")]
        // public Task<List<Player>> Ranges(int score)
        // {
        //     return _repository.Ranges(score);
        // }
        [HttpGet]
        [Route("sorting")]
        public async Task<List<Player>> Sorting()
        {
            return await _repository.Sorting();
        }
        // [HttpGet]
        // [Route("Subzero/{type:int}")]
        // public async Task<List<Player>> Subzero(int type)
        // {
        //     ItemType itemtype = new ItemType();
        //     if (type == 0)
        //     {
        //         itemtype = ItemType.SWORD;
        //     }
        //     if (type == 1)
        //     {
        //         itemtype = ItemType.POTION;
        //     }
        //     if (type == 2)
        //     {
        //         itemtype = ItemType.SHIELD;
        //     }
        //     return await _repository.Subzero(itemtype);
        // }
        // [HttpGet]
        // [Route("name/{name}")]
        // public Task<Player> Skeletor(string name)
        // {
        //     return _repository.Skeletor(name);
        // }
        // [HttpGet]
        // [Route("name/{id:Guid}")]
        // public async Task<Player> Skeletor2(Guid id)
        // {
        //     return await _repository.Skeletor2(id);
        // }
        [HttpPost]
        public async Task<Player> Create([FromBody] Player player)
        {
            Player _player = new Player();
            _player.Id = Guid.NewGuid();
            _player.namer = player.namer;
            _player.UserName = player.UserName;
            _player.Score = player.Score;
            _player.Time = player.Time;
            _player.FloorsCleared = player.FloorsCleared;
            _player.EnemiesKilled = player.EnemiesKilled;
            _player.CreationTime = DateTime.UtcNow;

            await _repository.Create(_player);
            return _player;
        }

        // [HttpPost]
        // [Route("modify/{id:Guid}")]
        // public async Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        // {
        //     return await _repository.Modify(id, player);
        // }

        // [HttpDelete]
        // [Route("delete/{id:Guid}")]
        // public async Task<Player> Delete(Guid id)
        // {
        //     return await _repository.Delete(id);
        // }
    }
}