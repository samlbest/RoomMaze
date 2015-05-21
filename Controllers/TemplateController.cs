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
    [Route("Template")]
    public class TemplateController : Controller
    {

        [HttpGet]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index");
        }
        
        [Route("Room")]
        public IActionResult Room()
        {
            return View("Room");
        }
        
    }
}
