using Microsoft.AspNetCore.Mvc;
using AutoApp.Models;
using AutoApp.Controllers.Resources;
using AutoMapper;
using AutoApp.Persistence;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {

        private readonly IMapper mapper;
        private readonly AutoDbContext context;

        public VehiclesController(IMapper mapper, AutoDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await this.context.Models.FindAsync(vehicleResource.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid model id");
                return BadRequest(ModelState);
            }

            var vehicle = this.mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            this.context.Vehicles.Add(vehicle);
            await this.context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await context.Vehicles
                .Include(v => v.Features)
                .FirstOrDefaultAsync(v => v.Id == id);
            
            if (vehicle == null)
            {
                return NotFound();
            }
            
            this.mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await this.context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await context.Vehicles.FindAsync(id);
            
            if (vehicle == null)
            {
                return NotFound();
            }
            
            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles
                .Include(v => v.Features)
                .SingleOrDefaultAsync(v => v.Id == id);
            
            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleResource = mapper.Map<Vehicle, VehicleFeature>(vehicle);
            return Ok(vehicleResource);
        }
    }
}