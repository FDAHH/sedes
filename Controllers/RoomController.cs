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
            try
            {
                var building = _dbContext.Building.Single(a => (a.Id == BuildingID));
                // Init list if null
                
                building.Rooms = building.Rooms== null ?  new List<Room>(): building.Rooms;
                Room item = new Room
                {
                    Floor = Floor,
                    Name = Name
                };
                building.Rooms.Add(item);
                _dbContext.SaveChanges();
                return new AcceptedResult();
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("Cant find Building with Id:" + BuildingID);
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }
        }
    }
}
