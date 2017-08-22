using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    public class PlatformsController : Controller
    {
        private Context _context = null;

        public PlatformsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var platforms = _context.Platforms
                .OrderBy(p => p.Name)
                .ToList();

            return Ok(platforms);
        }
    }
}
