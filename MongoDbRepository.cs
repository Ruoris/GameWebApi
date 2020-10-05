using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using Newtonsoft.Json;

public class MongoDbRepository : IRepository
{

    //"mongodb://localhost:27017"
    private readonly IMongoCollection<Player> _playerCollection;
    private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;
    List<Player> players;
    public MongoDbRepository()
    {
        MongoClient mongoClient = new MongoClient("mongodb+srv://biolight:BioLight@kouluprojektit.3ftm0.mongodb.net/<dbname>?retryWrites=true&w=majority");
        var database = mongoClient.GetDatabase("HighScoreDB");
        _playerCollection = database.GetCollection<Player>("BioLightCollection");
        _bsonDocumentCollection = database.GetCollection<BsonDocument>("BioLightCollection");
    }
    public async Task<Player> Create(Player player)
    {
        await _playerCollection.InsertOneAsync(player);
        return player;
    }


    public async Task<List<Player>> GetFromPlayerByFloor(string namer)
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("FloorsCleared");
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }
    public async Task<List<Player>> GetAllByEnemiesKilled()
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("EnemiesKilled");
        var filter = Builders<Player>.Filter.Empty;
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;
    }
    public async Task<List<Player>> GetAllByFloor()
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("FloorsCleared");
        var filter = Builders<Player>.Filter.Empty;
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }
    public async Task<List<Player>> GetAllByScore()
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("Score");
        var filter = Builders<Player>.Filter.Empty;
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }
    public async Task<List<Player>> GetAllByTime()
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("TimeInFloat");
        var filter = Builders<Player>.Filter.Empty;
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }

    public async Task<List<Player>> GetFromPlayerByScore(string namer)
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("Score");
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }
    public async Task<List<Player>> GetFromPlayerByTime(string namer)
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("TimeInFloat");
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;
    }
    public async Task<List<Player>> GetFromPlayerByEnemiesKilled(string namer)
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("EnemiesKilled");
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;
    }
    // public async Task<Item> CreateItem(Guid playerId, Item item)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
    //     Player player = await _playerCollection.Find(filter).FirstAsync();

    //     if (player == null)
    //     {
    //         throw new NotFoundException("Player not found.");
    //     }

    //     if (player.itemList == null)
    //         player.itemList = new List<Item>();
    //     player.itemList.Add(item);
    //     await _playerCollection.ReplaceOneAsync(filter, player);
    //     return item;
    // }

    // public async Task<Player> Delete(Guid id)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
    //     return await _playerCollection.FindOneAndDeleteAsync(filter);
    // }

    // public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
    //     Player player = await _playerCollection.Find(filter).FirstAsync();
    //     Item itemToRemove = null;

    //     for (int j = 0; j < player.itemList.Count; j++)
    //     {
    //         if (player.itemList[j].itemId == itemId)
    //         {
    //             itemToRemove = player.itemList[j];
    //             player.itemList.RemoveAt(j);
    //             await _playerCollection.ReplaceOneAsync(filter, player);
    //             return itemToRemove;
    //         }
    //     }
    //     return itemToRemove;
    // }


    public async Task<Player> Get(string namer)
    {
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        return await _playerCollection.Find(filter).FirstAsync();
    }

    public async Task<List<Player>> GetAllFromPlayer(string namer)
    {
        var filter = Builders<Player>.Filter.Eq(p => p.namer, namer);
        List<Player> players = await _playerCollection.Find(filter).ToListAsync();
        return players;
    }
    public async Task<Player[]> GetAll()
    {
        var filter = Builders<Player>.Filter.Empty;
        List<Player> players = await _playerCollection.Find(filter).ToListAsync();
        return players.ToArray();
    }
    // public async Task<Item[]> GetAllItems(Guid playerId)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
    //     Player player = await _playerCollection.Find(filter).FirstAsync();
    //     return player.itemList.ToArray();
    // }

    // public async Task<Item> GetItem(Guid playerId, Guid itemId)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
    //     Player player = await _playerCollection.Find(filter).FirstAsync();
    //     for (int i = 0; i < player.itemList.Count; i++)
    //     {
    //         if (player.itemList[i].itemId == itemId)
    //             return player.itemList[i];
    //     }
    //     return null;
    // }

    // public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
    //     Player player2 = await _playerCollection.Find(filter).FirstAsync();
    //     player2.Score = player.Score;
    //     await _playerCollection.ReplaceOneAsync(filter, player2);
    //     return player2;
    // }

    // public async Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
    //     Player player = await _playerCollection.Find(filter).FirstAsync();

    //     for (int i = 0; i < player.itemList.Count; i++)
    //     {
    //         if (player.itemList[i].itemId == itemId)
    //         {
    //             player.itemList[i].level = item.level;
    //             await _playerCollection.ReplaceOneAsync(filter, player);
    //             return player.itemList[i];
    //         }

    //     }
    //     return null;
    // // }
    // public async Task<List<Player>> Ranges(int seekethNumber)
    // {
    //     var filter = Builders<Player>.Filter.Gt(p => p.Score, seekethNumber);
    //     List<Player> plauers = await _playerCollection.Find(filter).ToListAsync();
    //     return plauers;
    // }
    public async Task<List<Player>> Sorting()
    {
        SortDefinition<Player> sortDef = Builders<Player>.Sort.Descending("Score");
        var filter = Builders<Player>.Filter.Empty;
        IFindFluent<Player, Player> cursor =
            _playerCollection.Find(filter).Sort(sortDef).Limit(10);

        List<Player> plauers = await cursor.ToListAsync();
        // plauers.Sort()
        return plauers;

    }
    // public async Task<Player> Skeletor(string name)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.UserName, name);
    //     return await _playerCollection.Find(filter).FirstAsync();


    // }
    // public async Task<Player> Skeletor2(Guid id)
    // {
    //     var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
    //     return await _playerCollection.Find(filter).FirstAsync();

    //}

    // public async Task<List<Player>> Subzero(ItemType itemtype)
    // {
    //     var playersWithWeapons =
    //     Builders<Player>.Filter.ElemMatch<Item>(
    //     p => p.itemList,
    //     Builders<Item>.Filter.Eq(i => i.type, itemtype));


    //     return await _playerCollection.Find(playersWithWeapons).ToListAsync();

    // }


}


