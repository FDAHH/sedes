using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sedes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sedes.Data;
using Microsoft.EntityFrameworkCore;

namespace sedes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {

        private readonly ILogger<RoomController> _logger;
        private readonly SedesContext _dbContext;

        public RoomController(ILogger<RoomController> logger, SedesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {

            return _dbContext.Room
            .Include(a => a.Seats)
            .ToList();
        }

        [HttpPut]
        public IActionResult Put(int BuildingID, int Floor, string Name)
        {
            var dbresutl = _dbContext.Room.Add(new Room
            {
                BuildingID = BuildingID,
                Floor = Floor,
                Name = Name,
                Seats = new List<Seat>()
            });
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }

            return new OkObjectResult(dbresutl.Entity);
        }
    }
}
