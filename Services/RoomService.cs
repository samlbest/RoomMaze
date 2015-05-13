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
			private readonly IRoomObjectRepository _roomObjectRepository;
			
			public RoomService(IRoomRepository roomRepository, IRoomObjectRepository roomObjectRepository)
			{
				this._roomRepository = roomRepository;
				this._roomObjectRepository = roomObjectRepository;
			}
			
			public async Task<List<Room>> GetAllRooms()
			{
				var rooms = await _roomRepository.AllRooms();

				System.Console.WriteLine("before");
				foreach (var room in rooms)
				{
					room.RoomObjects = await _roomObjectRepository.ObjectsForRoom(room);
					
					if (room.ChildrenIds != null && room.ChildrenIds.Length > 0)
					{
						room.Children = await _roomRepository.GetByIds(room.ChildrenIds.ToList());
					}
					
					if (room.ParentId.HasValue)
					{
						room.Parent = await _roomRepository.GetById(room.ParentId.Value);
					}
 				}
 				System.Console.WriteLine("after");
// 				
// 				rooms.ForEach(async x => {
// 					x.RoomObjects = await _roomObjectRepository.ObjectsForRoom(x.Id);
// 				});
				System.Console.WriteLine(rooms);
				return rooms;
			}
			
	        public async Task<Room> GetById(ObjectId id)
			{
				System.Console.WriteLine("get by id serv");
				return await _roomRepository.GetById(id);	
			}
			
	        public async Task<ObjectId> AddRoom(AddRoomRequest model)
			{
				System.Console.WriteLine("add room serv");
				var room = new Room
				{
					Name = model.name,
					Description = model.description,
					ParentId = new ObjectId(model.parent_id)
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