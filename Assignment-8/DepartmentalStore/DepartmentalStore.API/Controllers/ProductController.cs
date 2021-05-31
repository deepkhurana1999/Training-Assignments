using AutoMapper;
using DepartmentalStore.Domain;
using DepartmentalStore.Domain.Models;
using DepartmentalStore.Repositories.core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ProductController(IProductRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        private ObjectResult ExceptionHandler()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Not able to perform the task.");
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAll(bool includeInventory = false)
        {
            var products = await _repository.GetAllProducts(includeInventory);
            var result = _mapper.Map<List<ProductModel>>(products);
            return result;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ProductModel>> GetProduct(string code, bool includeInventory = false)
        {
            try
            {
                var products = await _repository.GetProductByProductCode(code, includeInventory);
                var result = _mapper.Map<ProductModel>(products);
                return result;
            }
            catch (Exception)
            {

                return this.ExceptionHandler();
            }

        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> AddProductMember(Product product)
        {
            try
            {

                var url = _linkGenerator.GetPathByAction("GetProduct", "Product", new { id = product.Code });
                if (!string.IsNullOrWhiteSpace(url)) return BadRequest("Not able to generate the url.");
                
                _repository.Add(product);

                if (await _repository.SaveChangesAsync())
                {     
                        return Created(url, _mapper.Map<ProductModel>(product));
                }
                return BadRequest("Not able to save the data.");
            }
            catch (Exception)
            {
                return this.ExceptionHandler();
            }
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct(string code, ProductModel product)
        {
            try
            {
                var data = await _repository.GetProductByProductCode(code, false);
                if (data == null) return NotFound();
                _mapper.Map(product, data);
                _repository.Update(data);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ProductModel>(data);
                }
                return BadRequest("Not able to save the data.");
            }
            catch (Exception)
            {
                return this.ExceptionHandler();
            }
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProduct(string code)
        {
            try
            {
                var product = await _repository.GetProductByProductCode(code, true);
                if (product != null)
                {
                    _repository.Delete(product);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {
                return this.ExceptionHandler();
            }

        }
    }
}
