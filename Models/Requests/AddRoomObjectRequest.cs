using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;

namespace RoomMaze.Models
{
	public class AddRoomObjectRequest
	{
		public string name { get; set; }
		public string description { get; set; }
	}
}