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
    public class SeatController : ControllerBase
    {

        private readonly ILogger<RoomController> _logger;
        private readonly SedesContext _dbContext;

        public SeatController(ILogger<RoomController> logger, SedesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Seat> Get()
        {

            return _dbContext.Seat.ToList();
        }


        [HttpPut]
        public IActionResult Put(int RoomId, string name)
        {


            try
            {
                var room = _dbContext.Room.Single(a => (a.Id == RoomId));
                // Init list if null
                room.Seats = room.Seats== null ?  new List<Seat>(): room.Seats;
                room.Seats.Add(new Seat {name = name });
                _dbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("Cant find Room with Id:" + RoomId);
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }

            return new AcceptedResult();
        }
    }
}
