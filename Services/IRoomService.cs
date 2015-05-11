using System;
using System.Collections.Generic;
using MongoDB.Bson; 
using RoomMaze.Models;
using System.Threading.Tasks;

namespace RoomMaze.Services
{  
    public interface IRoomService
    {
        Task<List<Room>> GetAllRooms();  
		
        Task<Room> GetById(ObjectId id);
        Task<ObjectId> AddRoom(AddRoomRequest model);

        bool Remove(ObjectId id);
    }
}