
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


public interface IRepository
{
    Task<Player> Get(string name);
    Task<Player[]> GetAll();


    Task<List<Player>> GetAllByEnemiesKilled();
    Task<List<Player>> GetAllByFloor();
    Task<List<Player>> GetAllByScore();
    Task<List<Player>> GetAllByTime();
    Task<List<Player>> GetFromPlayerByFloor(string name);
    Task<List<Player>> GetFromPlayerByScore(string name);
    Task<List<Player>> GetFromPlayerByTime(string name);
    Task<List<Player>> GetFromPlayerByEnemiesKilled(string name);
    Task<Player> Create(Player player);
    // Task<Player> Modify(Guid id, ModifiedPlayer player);
    // Task<Player> Delete(Guid id);

    // Task<Item> CreateItem(Guid playerId, Item item);
    // Task<Item> GetItem(Guid playerId, Guid itemId);
    // Task<Item[]> GetAllItems(Guid playerId);
    // Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item);
    // Task<Item> DeleteItem(Guid playerId, Guid itemId);
    // Task<List<Player>> Ranges(int seekethNumber);
    Task<List<Player>> Sorting();
    // Task<Player> Skeletor(string name);
    // Task<List<Player>> Subzero(ItemType itemtype);
    // Task<Player> Skeletor2(Guid id);
}