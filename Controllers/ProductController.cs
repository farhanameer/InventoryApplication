using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApplication.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        private readonly IMapper _mapper;
        private readonly IShopRepository _shop;
        public ProductController(IProductRepository product,IMapper mapper
            ,IShopRepository shop)
        {
            _product = product;
            _mapper = mapper;
            _shop = shop;
        }


        [HttpGet("{id}",Name ="GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id==0)
            {
                return BadRequest("Please Enter Correct Id");
            }
            if (await _product.ProductExist(id))
            {
                return Ok(_mapper.Map<ProductReturnDto>(await _product.ProductById(id)));
            }
            return NotFound("No Product Was Found");
        }
        [Authorize]
        public async Task<IActionResult> AddProduct(ProductCreationDto product)
        {
            var productCreation = _mapper.Map<Product>(product);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId==null || userId=="")
            {
                return Unauthorized();
            }
            productCreation.ShopID = await _shop.ShopIdByUserId(userId);
            await _product.AddProduct(productCreation);
            return CreatedAtRoute("GetProduct", new { id = productCreation.ProductID }, _mapper.Map<ProductReturnDto>(productCreation));
        }
    }
}