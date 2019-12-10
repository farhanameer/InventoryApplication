using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Location;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _location;
        private readonly IMapper _mapper;
        public LocationController(ILocation location,IMapper mapper)
        {
            _location = location;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationCreationDto location)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var locationAdd = _mapper.Map<Location>(location);
            if (location==null)
            {
                return UnprocessableEntity();
            }
            if (await _location.AddLocation(locationAdd))
            {
                return CreatedAtRoute("GetCategory", new { id = locationAdd.LocationID }, _mapper.Map<LocationReturnDto>(locationAdd));
            }
            return BadRequest();
        }

        [HttpGet("{id}",Name ="GetCategory")]
        public async Task<IActionResult> GetLocation(int id)
        {
            if (id==0)
            {
                return BadRequest("Please Enter A Valid Id");
            }
            if (await _location.LocationExist(id))
            {
                return Ok(_mapper.Map<LocationReturnDto>(await _location.GetSingleLocationByID(id)));
            }
            return NotFound("No Location Was Found");
        }

        [HttpGet]
        public async Task<IActionResult> AllLocations()
        {
            var locations = await _location.AllLocations();
            if (locations==null)
            {
                return NotFound("No Locations Were Found");
            }
            return Ok(_mapper.Map<List<LocationReturnDto>>(locations));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (id==0)
            {
                return BadRequest("Please Enter A Valid ID");
            }
            if (await _location.LocationExist(id))
            {
                await _location.DeleteLocation(id);
                return NoContent();
            }
            return NotFound("No Location Was Found");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation([FromRoute]int id,[FromBody]LocationUpdateionDto location)
        {
            location.LocationID = id;
            if (id==0)
            {
                return BadRequest("Please Enter A Valid ID");
            }
            if (await _location.LocationExist(id))
            {
                var locationDb = await _location.GetSingleLocationByID(id);
                _mapper.Map(location, locationDb);
                await _location.UpdateLocation(locationDb);
                return NoContent();
            }
            return NotFound("No Location Was Found");
        }
    }
}