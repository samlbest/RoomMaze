using Microsoft.Framework.OptionsModel;
using RoomMaze.Models;
using System;
using System.Collections.Generic;
using System.Net;
using MongoDB.Driver;
using MongoDB.Bson;
using RoomMaze.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{

    public class RoomRepository : MongoRepository, IRoomRepository
    {
        public RoomRepository(IOptions<Settings> settings) : base(settings) { }
        
        public async Task<List<Room>> AllRooms()
        {
            var rooms = Database.GetCollection<Room>(Constants.RoomCollectionName).Find(new BsonDocument());
            return await rooms.ToListAsync();
        }

        public async Task<Room> GetById(ObjectId id)
        {
            var room = await base.Database.GetCollection<Room>(Constants.RoomCollectionName)
                                      .Find(x => x.Id == id)
                                      .FirstOrDefaultAsync();
                                      
            return room;
        }
    
        public async Task<ObjectId> Add(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException("room");
            }
            
            await base.Database.GetCollection<Room>(Constants.RoomCollectionName).InsertOneAsync(room);
            
            if (room.Parent != null)
            {
                
                var parent = await base.Database.GetCollection<Room>(Constants.RoomCollectionName)
                                .Find(x => x.Id == room.Parent.Value)
                                .FirstOrDefaultAsync();
                if (parent == null)
                {
                    // Roll back insert
                    await base.Database.GetCollection<Room>(Constants.RoomCollectionName)
                        .DeleteOneAsync(x => x.Id == room.Id);
                    throw new Exception("ParentId invalid");
                }
                
                var children = parent.Children.ToList();
                
                children.Add(room.Id);
                parent.Children = children.Distinct().ToArray();
                
                await base.Database.GetCollection<Room>(Constants.RoomCollectionName)
                                   .ReplaceOneAsync(x => x.Id == parent.Id, parent);
            }

            
            return room.Id;
        }
    
        public void Update(Room room)
        {
            throw new NotImplementedException();
        }
    
        public bool Remove(ObjectId id)
        {
            throw new NotImplementedException();
        }
    }
}