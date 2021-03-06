using System;
using System.Collections.Generic;
using MongoDB.Bson; 
using System.Linq.Expressions;
using RoomMaze.Models;
using System.Threading.Tasks;

namespace RoomMaze.Repositories
{  
    public interface IRoomRepository
    {
        Task<List<Room>> AllRooms();  
        
        Task<List<Room>> FindRooms(Expression<Func<Room, bool>> expression);
        Task<Room> GetById(ObjectId id);
        Task<List<Room>> GetByIds(List<ObjectId> ids);
        Task<ObjectId> Add(Room Room);
        void Update(Room room);
        bool Remove(ObjectId id);
    }
}