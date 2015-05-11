using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;

namespace RoomMaze.Models
{
	public class AddRoomRequest
	{
		public string name { get; set; }
		public string description { get; set; }
		public string parent_id { get; set; }
	}
}