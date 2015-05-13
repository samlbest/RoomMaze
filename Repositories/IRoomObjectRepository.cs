using System;
using System.Collections.Generic;
using MongoDB.Bson; 
using RoomMaze.Models;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{  
    public interface IRoomObjectRepository
    {
        Task<List<RoomObject>> AllRoomObjects();
        
        Task<List<RoomObject>> ObjectsForRoom(Room room);
        Task<RoomObject> GetById(ObjectId id);
        Task<ObjectId> Add(RoomObject roomObject);
        void Update(RoomObject roomObject);
        bool Remove(ObjectId roomObjectId, ObjectId roomId);
    }
}