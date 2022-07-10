using Microsoft.AspNetCore.Mvc;
using NZWalks.API.ASPNet.Models.DTO;
using NZWalks.API.ASPNet.Repositories;
using NZWalks.API.ASPNet.Models.Domain;
using AutoMapper;

namespace NZWalks.API.ASPNet.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(IRegionRepository regionRepository,IMapper mapper)
        {

            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllRegionAsync();
            //
            // Retrunig data
            //
            //var regionsDto = new List<RegionDTO>();

            //regions.ToList().ForEach(region =>
            //{
            //    var regionDto = new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //       Area = region.Area,
            //       lat=region.lat,
            //       Population= region.Population,
            //       Code=region.Code,
            //       Long=region.Long,
            //    };
            //    regionsDto.Add(regionDto);
            //});
            var regionsDTO=mapper.Map<List<Region>>(regions);

            return Ok(regionsDTO);

        }
          
    }
}
