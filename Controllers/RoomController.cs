using Microsoft.AspNet.Mvc;
using RoomMaze.Services;
using RoomMaze.Models;
using System.Net;

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
        
        [HttpPost]
        public async void AddRoom([FromBody] AddRoomRequest model)
        {
			System.Console.WriteLine("add room cont");
            
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            
            else
            {
                var roomId = await _roomService.AddRoom(model);
                Response.StatusCode = (int)HttpStatusCode.Created;

                Response.Headers["Location"] = string.Format("/api/rooms/{0}", roomId);
                
                Console.WriteLine(Response.Headers["Location"]);
            }

        }
    }
}
