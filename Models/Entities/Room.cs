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
			this.ObjectIds = new List<ObjectId>().ToArray();
			this.ChildrenIds = new List<ObjectId>().ToArray();
			this.RoomObjects = new List<RoomObject>();
		}
		
		public ObjectId Id { get; set; }
		
		[BsonElement("name")]
		public string Name { get; set; }
		
		[BsonElement("description")]
	    public string Description { get; set; }
		
		[BsonElement("parent")]
		public Nullable<ObjectId> ParentId { get; set; }
		
		[BsonElement("children")]
		public ObjectId[] ChildrenIds { get; set; }
		
		[BsonElement("objects")]
		public ObjectId[] ObjectIds { get; set; }
		
		[BsonIgnoreAttribute]
		public List<RoomObject> RoomObjects { get; set; }
		
		[BsonIgnoreAttribute]
		public List<Room> Children { get; set; }
		
		[BsonIgnoreAttribute]
		public Room Parent { get; set; }

	}
}