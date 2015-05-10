using System;
using System.Collections.Generic;
using MongoDB.Bson; 
using RoomMaze.Models;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{  
    public interface IRoomRepository
    {
        Task<List<Room>> AllRooms();  
        Room GetById(ObjectId id);
        void Add(Room Room);
        void Update(Room room);
        bool Remove(ObjectId id);
    }
}