using Microsoft.AspNetCore.Mvc;
using NZWalks.API.ASPNet.Models.DTO;
using NZWalks.API.ASPNet.Repositories;
using NZWalks.API.ASPNet.Models.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace NZWalks.API.ASPNet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class RegionController : ControllerBase
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
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("getRegionAsync")]
        public async Task<IActionResult> getRegionAsync(Guid id)
        {
            var region = await regionRepository.GetRegionAsync(id);


            if(region == null)
            {
                return NotFound();
            }
            var regiondto=mapper.Map<RegionDTO>(region);
            return Ok(regiondto);

         }
        /// <summary>
         /// Thi
         /// </summary>
         /// <param name="addRegionRequest"></param>
         /// <returns></returns>
        [HttpPost]
        
        public async Task<IActionResult> addRegionAsync(AddRegionRequest addRegionRequest)

        {
            var region = new Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                lat = addRegionRequest.lat,
                Population = addRegionRequest.Population,
                Name = addRegionRequest.Name,
                Long = addRegionRequest.Long
            };
            region=await regionRepository.AddAsync(region);

            var regiondto = new RegionDTO()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                lat = region.lat,
                Area = region.Area,
                Long = region.Long,
                Population = region.Population
            };
            return CreatedAtAction(nameof(getRegionAsync), new { id = regiondto.Id }, regiondto); 
        }
        /// <summary>
        /// This action method use for deleting particuler region record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> deleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            /// if no record for delete
            if(region == null)
            {
                return NotFound();
            }

            var regiondto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                lat = region.lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            return Ok(regiondto);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRegionRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id,
            [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            // Validate the incoming request
            //if (!ValidateUpdateRegionAsync(updateRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            // Convert DTO to Domain model
            var region = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Area = updateRegionRequest.Area,
                lat = updateRegionRequest.lat,
                Long = updateRegionRequest.Long,
                Name = updateRegionRequest.Name,
                Population = updateRegionRequest.Population
            };


            // Update Region using repository
            region = await regionRepository.UpdateAsync(id, region);


            // If Null then NotFound
            if (region == null)
            {
                return NotFound();
            }

            // Convert Domain back to DTO
            var regiondto = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                lat = region.lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };


            // Return Ok response
            return Ok(regiondto);
        }

    }
}
