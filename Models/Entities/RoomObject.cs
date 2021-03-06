using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;

namespace RoomMaze.Models
{
	public class RoomObject
	{
		public ObjectId Id { get; set; }
		
		[BsonElement("name")]
		public string Name { get; set; }
		
		[BsonElement("description")]
	    public string Description { get; set; }
	}
}