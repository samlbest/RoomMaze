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
        
        Task<Room> GetRootRoom();
        Task<List<RoomObject>> GetAllRoomObjects();  
		
        Task<Room> GetById(ObjectId id);
        
        Task<ObjectId> AddRoom(AddRoomRequest model);
        
        Task<ObjectId> AddRoomObject(AddRoomObjectRequest model);
        
        void AddObjectToRoom(ObjectId roomId, ObjectId objectId);

        bool Remove(ObjectId id);
        
    }
}