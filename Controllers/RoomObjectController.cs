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
    public class RoomObjectController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomObjectController(IRoomService roomService)
        {
            this._roomService = roomService;
        }
       
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllRoomObjects();
            return new ObjectResult(rooms);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddRoomObject([FromBody] AddRoomObjectRequest model)
        {
            
            if (!ModelState.IsValid)
            {
                return HttpBadRequest();
            }
            
            var roomId = await _roomService.AddRoomObject(model);
            Response.Headers["Location"] = string.Format("/api/roomobject/{0}", roomId);
            return new HttpStatusCodeResult((int)HttpStatusCode.Created);
        }
    }
}
