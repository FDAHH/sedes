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
    public class ReservationController : ControllerBase
    {

        private readonly ILogger<ReservationController> _logger;
        private readonly SedesContext _dbContext;

        public ReservationController(ILogger<ReservationController> logger, SedesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get()
        {

            return _dbContext.Reservation.Include(a => a.Person).Include(s => s.Seat).ToList();
        }


        [HttpPut]
        public IActionResult Put(int PersonId, int SeatId, DateTime start, DateTime end)
        {
            try
            {
                var person = _dbContext.Person.Single(a => (a.Id == PersonId));
                var seat = _dbContext.Seat.Single(a => (a.Id == SeatId));
                var reservation = new Reservation {
                    Person = person,
                    Seat = seat,
                    Start = start,
                    End = end
                };
                
                var dbResult =_dbContext.Reservation.Add(reservation);
                 _dbContext.SaveChanges();
                return new OkObjectResult(dbResult.Entity);
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult($"Cant find Person: {PersonId} or Seat: {SeatId}");
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }            
        }
    }
}
