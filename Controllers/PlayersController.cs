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
        [Route("{id:Guid}")]
        public async Task<Player> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<Player[]> GetAll()
        {
            return await _repository.GetAll();
        }
        [HttpGet]
        [Route("Minscore/{score:int:min(0)}")]
        public async Task<List<Player>> Ranges(int score)
        {
            return await _repository.Ranges(score);
        }
        [HttpGet]
        [Route("sorting")]
        public async Task<List<Player>> Sorting()
        {
            return await _repository.Sorting();
        }
        [HttpGet]
        [Route("Subzero/{type:ItemType")]
        public async Task<List<Player>> Subzero(ItemType type)
        {
            return await _repository.Subzero(type);
        }
        [HttpGet]
        [Route("{name}")]
        public async Task<Player> Skeletor(string name)
        {
            return await _repository.Skeletor(name);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<Player> Skeletor2(Guid id)
        {
            return await _repository.Skeletor2(id);
        }
        [HttpPost]
        public async Task<Player> Create([FromBody] NewPlayer newplayer)
        {
            Player _player = new Player();
            _player.Id = Guid.NewGuid();
            _player.Name = newplayer.Name;
            _player.CreationTime = DateTime.UtcNow;

            await _repository.Create(_player);
            return _player;
        }

        [HttpPost]
        [Route("modify/{id:Guid}")]
        public async Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            return await _repository.Modify(id, player);
        }

        [HttpDelete]
        [Route("delete/{id:Guid}")]
        public async Task<Player> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}