using Microsoft.AspNetCore.Mvc;
using AutoApp.Models;
using AutoApp.Controllers.Resources;
using AutoMapper;
using AutoApp.Persistence;
using System.Threading.Tasks;
using System;

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

            var model = await context.Vehicles.Include(v => v.Features).FindAsync(id);
            
            this.mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await this.context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}