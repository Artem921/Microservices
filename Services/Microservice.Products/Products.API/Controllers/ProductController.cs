﻿using MassTransit;
using MassTransit.Contract.DTO.Product;
using MassTransit.Contract.DTO.Product.Request;
using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
    
        private readonly IPublishEndpoint publishEndpoint;

        public ProductController(  IPublishEndpoint publishEndpoint)
        {

            this.publishEndpoint = publishEndpoint;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productVM)
        {
            await publishEndpoint.Publish<CreateProductRequest>(new 
            { 
                productVM
            });

       

            return Ok();
        }
    }
}
