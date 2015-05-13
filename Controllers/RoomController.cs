using Microsoft.AspNet.Mvc;
using RoomMaze.Services;
using RoomMaze.Models;
using System.Net;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomMaze.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            this._roomService = roomService;
        }
       
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllRooms();
            return new ObjectResult(rooms);
        }
        
        [HttpGet]
        [Route("{id}", Name = "GetRoomById")]
        public async Task<ActionResult> GetRoomById(string id)
        {
            return new ObjectResult(await _roomService.GetById(new ObjectId(id)));
        }
        
        [HttpPut]
        [Route("{roomId}/object/{objectId}", Name = "AddObjectToRoom")]
        public async Task<ActionResult> AddObjectToRoom(string roomId, string objectId)
        {

            _roomService.AddObjectToRoom(new ObjectId(roomId), new ObjectId(objectId));
            return new HttpStatusCodeResult((int)HttpStatusCode.OK);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddRoom([FromBody] AddRoomRequest model)
        {
			System.Console.WriteLine("add room cont");
            
            if (!ModelState.IsValid)
            {
                return HttpBadRequest();
            }
        
            if (model.parent_id != null)
            {
                if (await _roomService.GetById(new ObjectId(model.parent_id)) == null)
                {
                    return HttpNotFound(string.Format("No room with id '{0}' exists.", model.parent_id));
                }
            }
            
            var roomId = await _roomService.AddRoom(model);
            Response.Headers["Location"] = string.Format("/api/rooms/{0}", roomId);
            return new HttpStatusCodeResult((int)HttpStatusCode.Created);
        }
    }
}
