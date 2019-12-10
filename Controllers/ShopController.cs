using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ConcreteRepos;
using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Location;
using InventoryApplication.HelperModels.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Controllers
{
    [Authorize]
    [Route("api/shops")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        private readonly ILocation _location;
        public ShopController(IShopRepository shopRepository,IMapper mapper
            ,ILocation location)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
            _location = location;
        }

        public async Task<IActionResult> AllShops()
        {
            var shops = await _shopRepository.GetAllShops();
            if (shops!=null)
            {
                return NotFound("No Registered Shop Found");
            }
            return Ok(_mapper.Map<List<ShopReturnDto>>(shops));
        }

        [HttpGet("{id}",Name ="GetShop")]
        public async Task<IActionResult> GetShop(int id)
        {
            if (id==0)
            {
                return BadRequest("Please Enter A Vali ID");
            }
            if (User.IsInRole("Admin"))
            {
                if (!await _shopRepository.ShopExist(id))
                {
                    return NotFound("No Shop Was Found");
                }
                return Ok(_mapper.Map<ShopReturnDto>(await _shopRepository.GetSingleShop(id,null)));
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await _shopRepository.ShopExistByUserID(userId))
            {
                return Unauthorized("You Don't Have Permission To Check");
            }
            if (await _shopRepository.ShopExistByUserID(userId))
            {
                var shop = await _shopRepository.GetSingleShop(id, userId);
                if (shop == null)
                {
                    return Unauthorized("You Don't Have Permission To Check");
                }
                return Ok(_mapper.Map<ShopReturnDto>(await _shopRepository.GetSingleShop(id, userId)));
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddShop(ShopCreationDto shop)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await _shopRepository.ShopExistByUserID(userId))
            {
                var shopCreation = _mapper.Map<Shop>(shop);
                var location = _mapper.Map<Location>(shop);
                shopCreation.Location = location;
                shopCreation.UserId = userId;
                if (await _shopRepository.AddShop(shopCreation))
                {
                    var shopReturn = _mapper.Map<ShopReturnDto>(shopCreation);
                    return CreatedAtRoute("GetShop", new { id = shopCreation.ShopID }, shopReturn);
                }
                return BadRequest();
            }
            return BadRequest("You Already Own a shop, You can't create More than one shop");
        }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateShop([FromRoute]int id,ShopUpdationDto shop)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (await _shopRepository.ShopExistByUserID(userId))
            {
                var shopDb = await _shopRepository.GetSingleShop(id,userId);
                await _shopRepository.UpdateShop(_mapper.Map(shop,shopDb));
                return NoContent();
            }
            return NotFound("No Shop Was Found");
        }
    }
}