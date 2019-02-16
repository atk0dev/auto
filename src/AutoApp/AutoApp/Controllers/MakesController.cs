using System.Collections.Generic;
using System.Threading.Tasks;
using AutoApp.Controllers.Resources;
using AutoApp.Models;
using AutoApp.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Controllers
{       
    public class MakesController : Controller
    {
        private readonly AutoDbContext context;
        private readonly IMapper mapper;

        public MakesController(AutoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await this.context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }         
    }
}