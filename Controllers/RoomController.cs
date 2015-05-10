using Microsoft.AspNet.Mvc;
using RoomMaze.Repositories;
using RoomMaze.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomMaze.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
           


            this._roomRepository = roomRepository;
        }
       
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {


            var rooms = await _roomRepository.AllRooms();
    	    System.Console.WriteLine("???");
            return new ObjectResult(rooms);
        }
    }
}
