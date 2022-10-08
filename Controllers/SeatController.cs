using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sedes.Data;
using sedes.Models;
using sedes.Models.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sedes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeatController : ControllerBase
    {

        private readonly ILogger<RoomController> _logger;
        private readonly SedesContext _dbContext;
        private readonly IMapper _mapper;

        public SeatController(ILogger<RoomController> logger, SedesContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all Seats.
        /// </summary>
        /// <group>Seat</group>
        /// <verb>Get</verb>
        /// <param name="RoomId" cref="int">Room id </param>
        /// <response code="200"><see cref="Seat"/>Sample object retrieved</response>
        /// <returns>The list of seat</returns>
        [HttpGet]
        [EnableQuery]
        public IQueryable<ZSeat> Get()
        {
            return _dbContext.Seat.ProjectTo<ZSeat>(_mapper.ConfigurationProvider);
        }

        /// <summary>
        /// Add a new Seat.
        /// </summary>
        /// <group>Seat</group>
        /// <verb>Put</verb>
        /// <param name="RoomId" cref="int">Header param 1</param>
        /// <param name="Name" cref="string">The object id</param>
        /// <response code="201"><see cref="SampleObject1"/>Sample object retrieved</response>
        /// <returns>The sample object 1</returns>
        [HttpPut]
        public IActionResult Put(int RoomId, string Name)
        {
            try
            {
                var room = _dbContext.Room.Single(a => (a.Id == RoomId));
                // Init list if null
                room.Seats = room.Seats == null ? new List<Seat>() : room.Seats;
                room.Seats.Add(new Seat { Name = Name });
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
