using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    public class VideoGamesController : Controller
    {
        private static List<VideoGame> _videoGames = new List<VideoGame>()
        {
            new VideoGame()
            {
                Id = 1,
                Title = "Super Mario 64",
                PublishedOn = new DateTime(1996, 1, 1),
                Platform = "N64"
            },
            new VideoGame()
            {
                Id = 2,
                Title = "Resident Evil",
                PublishedOn = new DateTime(1994, 1, 1),
                Platform = "Playstation"
            },
            new VideoGame()
            {
                Id = 3,
                Title = "Halo",
                PublishedOn = new DateTime(2000, 1, 1),
                Platform = "Xbox"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_videoGames);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var videoGame = _videoGames
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
            // TODO set the Id value

            if (videoGame != null)
            {
                _videoGames.Add(videoGame);
            }

            return Created($"/api/videogames/{videoGame.Id}", videoGame);
        }
    }
}
