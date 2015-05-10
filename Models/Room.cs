using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RoomMaze.Models
{
	public class Room
	{
		public ObjectId Id { get; set; }
		
		[BsonElement("description")]
	    public string Description { get; set; }
	}
}