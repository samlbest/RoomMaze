using Microsoft.Framework.OptionsModel;
using RoomMaze.Models;
using System;
using System.Collections.Generic;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{

    public class RoomRepository : IRoomRepository
    {
        private readonly IOptions<Settings> _settings;
        private readonly IMongoDatabase _database;

        public RoomRepository(IOptions<Settings> settings)
        {
            this._settings = settings;
            this._database = Connect();
            System.Console.WriteLine("repo constructor finished");
        }
        public async Task<List<Room>> AllRooms()
        {
            var rooms = _database.GetCollection<Room>("rooms").Find(new BsonDocument());
            return await rooms.ToListAsync();
        }

        public Room GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }
    
        public void Add(Room Room)
        {
            throw new NotImplementedException();
        }
    
        public void Update(Room room)
        {
            throw new NotImplementedException();
        }
    
        public bool Remove(ObjectId id)
        {
            throw new NotImplementedException();
        }
        
        private IMongoDatabase Connect()
        {

            var client = new MongoClient(_settings.Options.MongoConnection);

            var database = client.GetDatabase(_settings.Options.Database);
            System.Console.WriteLine(_settings.Options.Database);
            return database;
        }
    }
}