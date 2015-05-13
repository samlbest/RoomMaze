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

    public class RoomObjectRepository : MongoRepository, IRoomObjectRepository
    {
        public RoomObjectRepository(IOptions<Settings> settings) : base(settings) { }
        
        public async Task<List<RoomObject>> AllRoomObjects()
        {
            return await base.Database.GetCollection<RoomObject>(Constants.RoomObjectCollectionName)
                            .Find(new BsonDocument())
                            .ToListAsync();
        }
        
        public async Task<List<RoomObject>> ObjectsForRoom(Room room)
        {
                                 
            if (room == null || room.ObjectIds == null  || room.ObjectIds.Length == 0)
            {
                return new List<RoomObject>();
            }
            
            var roomObjectIds = room.ObjectIds.ToList();
            
            var roomObjects = await base.Database
                                        .GetCollection<RoomObject>(Constants.RoomObjectCollectionName)
                                        .Find(x => roomObjectIds.Contains(x.Id))
                                        .ToListAsync();
                                      
            return roomObjects;
        }
        public async Task<RoomObject> GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }
        public async Task<ObjectId> Add(RoomObject roomObject)
        {
            if (roomObject == null)
            {
                throw new ArgumentNullException("roomObject");
            }
            
            await base.Database.GetCollection<RoomObject>(Constants.RoomObjectCollectionName).InsertOneAsync(roomObject);
            
            return roomObject.Id;
        }
        public void Update(RoomObject roomObject)
        {
            throw new NotImplementedException();
        }
        public bool Remove(ObjectId roomObjectId, ObjectId roomId)
        {
            throw new NotImplementedException();
        }
    }
}