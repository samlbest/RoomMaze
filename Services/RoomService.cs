using RoomMaze.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using RoomMaze.Models;
using System.Linq;

using MongoDB.Driver;
using MongoDB.Bson;

namespace RoomMaze.Services
{
        public class RoomService : IRoomService
		{
			private readonly IRoomRepository _roomRepository;
			
			public RoomService(IRoomRepository roomRepository)
			{
				this._roomRepository = roomRepository;
			}
			
			public Task<List<Room>> GetAllRooms()
			{
				return _roomRepository.AllRooms();
			}
			
	        public Task<Room> GetById(ObjectId id)
			{
				System.Console.WriteLine("get by id serv");
				return _roomRepository.GetById(id);	
			}
			
	        public async Task<ObjectId> AddRoom(AddRoomRequest model)
			{
				System.Console.WriteLine("add room serv");
				var room = new Room
				{
					Name = model.name,
					Description = model.description,
					Parent = new ObjectId(model.parent_id)
				};
				
				
				var id = await _roomRepository.Add(room);
				
				return id;
			}
	
	        public bool Remove(ObjectId id)
			{
				return _roomRepository.Remove(id);
			}
		}
}