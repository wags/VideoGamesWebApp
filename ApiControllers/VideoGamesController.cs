using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    public class VideoGamesController : Controller
    {
        private Context _context = null;

        public VideoGamesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var videoGames = _context.VideoGames
                .Include(vg => vg.Platform)
                .OrderBy(vg => vg.Title)
                .ToList();

            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var videoGame = _context.VideoGames
                .Where(vg => vg.Id == id)
                .SingleOrDefault();

            // TODO return 404 if video game is not found
            if (videoGame == null)
            {
                return NotFound();
            }

            return Ok(videoGame);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VideoGame videoGame)
        {
            if (videoGame == null)
            {
                return BadRequest();
            }

            _context.VideoGames.Add(videoGame);
            _context.SaveChanges();

            return Created($"/api/videogames/{videoGame.Id}", videoGame);
        }
    }
}
