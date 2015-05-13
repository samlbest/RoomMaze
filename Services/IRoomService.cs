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
        Task<List<RoomObject>> GetAllRoomObjects();  
		
        Task<Room> GetById(ObjectId id);
        
        Task<ObjectId> AddRoom(AddRoomRequest model);
        
        Task<ObjectId> AddRoomObject(AddRoomObjectRequest model);

        bool Remove(ObjectId id);
        
    }
}