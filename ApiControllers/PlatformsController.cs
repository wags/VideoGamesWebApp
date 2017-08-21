using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    public class PlatformsController : Controller
    {
        private static List<Platform> _platforms = new List<Platform>()
        {
            new Platform() { Id = 1, Name ="N64" },
            new Platform() { Id = 2, Name ="GameCube" },
            new Platform() { Id = 3, Name ="Wii" },
            new Platform() { Id = 4, Name ="Wii U" },
            new Platform() { Id = 5, Name ="Switch" },
            new Platform() { Id = 6, Name ="PlayStation" },
            new Platform() { Id = 7, Name ="PlayStation 2" },
            new Platform() { Id = 8, Name ="PlayStation 3" },
            new Platform() { Id = 9, Name ="PlayStation 4" },
            new Platform() { Id = 10, Name ="Xbox" },
            new Platform() { Id = 11, Name ="Xbox 360" },
            new Platform() { Id = 12, Name ="Xbox One" }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_platforms);
        }
    }
}
