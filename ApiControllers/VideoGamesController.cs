using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ApiControllers
{
    public class VideoGamesController : Controller
    {
        public IActionResult Get()
        {
            var videoGames = new List<VideoGame>()
            {
                new VideoGame()
                {
                   Id = 1,
                   Title = "Super Mario 64",
                   PublishedOn = new DateTime(1996, 1, 1),
                   Platform = ""
                },
                new VideoGame()
                {
                    Id = 2,
                    Title = "Resident Evil",
                    PublishedOn = new DateTime(1994, 1, 1),
                    Platform = "Playstation"
                }
            };

            return Ok(videoGames);
        }
    }
}
