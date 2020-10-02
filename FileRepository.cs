

using System;

using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Collections.Generic;
public class Ratkaisija
{
    public List<Player> playerLista = new List<Player>();

}
public class FileRepository /*: IRepository*/
{

}


//     public async Task<Player> Create(Player player)
//     {
//         Ratkaisija players = await ReadFile();
//         players.playerLista.Add(player);
//         File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//         return player;
//     }

//     public async Task<Item> CreateItem(Guid playerId, Item item)
//     {
//         Ratkaisija players = await ReadFile();
//         Player playerToGetItem = new Player();
//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == playerId)
//             {
//                 playerToGetItem = players.playerLista[i];
//             }
//         }
//         if (playerToGetItem.itemList == null)
//             playerToGetItem.itemList = new List<Item>();
//         playerToGetItem.itemList.Add(item);
//         File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//         return item;
//     }

//     public async Task<Item> GetItem(Guid playerId, Guid itemId)
//     {
//         Ratkaisija players = await ReadFile();
//         Item itemToGet = new Item();
//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == playerId)
//             {
//                 for (int j = 0; j < players.playerLista[i].itemList.Count; j++)
//                 {
//                     if (players.playerLista[i].itemList[j].itemId == itemId)
//                     {
//                         itemToGet = players.playerLista[i].itemList[j];
//                         return itemToGet;
//                     }
//                 }
//             }
//         }
//         return null;
//     }
//     public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
//     {
//         Ratkaisija players = await ReadFile();
//         Item itemToRemove = new Item();
//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == playerId)
//             {
//                 for (int j = 0; j < players.playerLista[i].itemList.Count; j++)
//                 {
//                     if (players.playerLista[i].itemList[j].itemId == itemId)
//                     {
//                         itemToRemove = players.playerLista[i].itemList[j];
//                         players.playerLista[i].itemList.RemoveAt(j);
//                         File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//                         return itemToRemove;
//                     }
//                 }
//             }
//         }
//         return null;
//     }

//     public async Task<Item[]> GetAllItems(Guid playerId)
//     {
//         Ratkaisija players = await ReadFile();
//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == playerId)
//             {
//                 return players.playerLista[i].itemList.ToArray();
//             }
//         }
//         return null;
//     }

//     public async Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item)
//     {
//         Ratkaisija players = await ReadFile();

//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == playerId)
//             {
//                 for (int j = 0; j < players.playerLista[i].itemList.Count; j++)
//                 {
//                     if (players.playerLista[i].itemList[j].itemId == itemId)
//                     {
//                         players.playerLista[i].itemList[j].level = item.level; // tässä nyt on päätetty että updateitemilla muutetaan itemin leveliä
//                         File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//                         return players.playerLista[i].itemList[j];
//                     }
//                 }
//             }
//         }
//         return null;
//     }

//     public async Task<Player> Delete(Guid id)
//     {
//         Ratkaisija players = await ReadFile();

//         Player playerToDelete = new Player();
//         for (int i = 0; i < players.playerLista.Count; i++)
//         {
//             if (players.playerLista[i].Id == id)
//             {
//                 playerToDelete = players.playerLista[i];
//                 players.playerLista.RemoveAt(i);
//                 File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//                 return playerToDelete;
//             }
//         }

//         return null;
//     }

//     public async Task<Player> Get(Guid id)
//     {
//         Ratkaisija players = await ReadFile();

//         Player playerToGet = new Player();
//         foreach (Player player in players.playerLista)
//         {
//             if (player.Id == id)
//             {
//                 playerToGet = player;
//                 return playerToGet;
//             }
//         }
//         return null;
//     }

//     public async Task<Player[]> GetAll()
//     {
//         Ratkaisija players = await ReadFile();
//         return players.playerLista.ToArray();
//     }



//     public async Task<Player> Modify(Guid id, ModifiedPlayer player)
//     {
//         Ratkaisija players = await ReadFile();
//         Player playerToModify = new Player();
//         foreach (Player oldplayer in players.playerLista)
//         {
//             if (oldplayer.Id == id)
//             {
//                 oldplayer.Score = player.Score;
//                 playerToModify = oldplayer;
//                 File.WriteAllText("game-dev.txt", JsonConvert.SerializeObject(players));
//             }
//         }
//         return playerToModify;
//     }
//     public async Task<Ratkaisija> ReadFile()
//     {
//         var players = new Ratkaisija();
//         string json = await File.ReadAllTextAsync("game-dev.txt");

//         if (File.ReadAllText("game-dev.txt").Length != 0)
//         {
//             return JsonConvert.DeserializeObject<Ratkaisija>(json);
//         }
//         return players;
//     }


// }
