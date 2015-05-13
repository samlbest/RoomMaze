using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;

namespace RoomMaze.Models
{
	public class Room
	{
		public Room()
		{
			this.Objects = new List<ObjectId>().ToArray();
			this.Children = new List<ObjectId>().ToArray();
			this.RoomObjects = new List<RoomObject>();
		}
		
		public ObjectId Id { get; set; }
		
		[BsonElement("name")]
		public string Name { get; set; }
		
		[BsonElement("description")]
	    public string Description { get; set; }
		
		[BsonElement("parent")]
		public Nullable<ObjectId> Parent { get; set; }
		
		[BsonElement("children")]
		public ObjectId[] Children { get; set; }
		
		[BsonElement("objects")]
		public ObjectId[] Objects { get; set; }
		
		[BsonIgnoreAttribute]
		public List<RoomObject> RoomObjects { get; set; }

	}
}