using System.Collections.Generic;
using System.Threading.Tasks;
using AutoApp.Controllers.Resources;
using AutoApp.Core.Models;
using AutoApp.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoApp.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly AutoDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(AutoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await this.context.Features.ToListAsync();
            return this.mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}