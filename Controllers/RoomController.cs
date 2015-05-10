using Microsoft.AspNet.Mvc;
using RoomMaze.Repositories;
using RoomMaze.Models;
using System.Collections.Generic;
using System;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomMaze.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
           
        	System.Console.WriteLine("hit constructor room all");

            this._roomRepository = roomRepository;
        }
       
        [HttpGet]
        public Room GetAll()
        {
            System.Console.WriteLine("hit get all");

            var room = new Room
            {
                Description = "hi"

            };
    	    return room;
            //return new ContentResult(_roomRepository.AllRooms());
        }
    }
}
