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
    public class BuildingController : ControllerBase
    {

        private readonly ILogger<BuildingController> _logger;
        private readonly SedesContext _dbContext;

        public BuildingController(ILogger<BuildingController> logger, SedesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Building> Get()
        {

            return _dbContext.Building
            .Include(a => a.Rooms)
            .ToList();
        }

        [HttpPut]
        public IActionResult Put(string Name)
        {
            try
            {
                Building item = new Building
                {
                    Name = Name
                };
                var dbResult = _dbContext.Building.Add(item);
                _dbContext.SaveChanges();
                return new OkObjectResult(dbResult.Entity);
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult("Cant find Building with Id:" );
            }
            catch (DbUpdateException e)
            {
                //TODO: should not expose Error Message to Caller
                return new BadRequestObjectResult(e.InnerException?.Message);
            }
        }
    }
}
