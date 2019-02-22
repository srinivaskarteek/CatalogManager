using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE.Catalog.Contracts;
using SE.Catalog.Models;

namespace SE.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFamilyController : ControllerBase
    {
        private IRepositoryBase<ProductFamily> _productFamilyRepository;
        public ProductFamilyController(IRepositoryBase<ProductFamily> context)
        {
            _productFamilyRepository = context;
        }

        // POST: api/ProductFamily
        [HttpPost]
        public async Task<IActionResult> PostProductFamily([FromBody] ProductFamily productFamily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productFamilyRepository.Add(productFamily);
            await _productFamilyRepository.SaveAsync();

            return CreatedAtAction("GetProductFamily", new { id = productFamily.Id }, productFamily);
        }

        // GET: api/ProductFamily
        [HttpGet]
        public IEnumerable<ProductFamily> GetProductFamily()
        {
            return _productFamilyRepository.GetAll();
        }

        // GET: api/ProductFamily/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var productFamily = await _productFamilyRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (productFamily == null)
            {
                return NotFound();
            }

            return Ok(productFamily);
        }

        // PUT: api/ProductFamily/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductFamily([FromRoute] int id, [FromBody] ProductFamily productFamily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productFamily.Id)
            {
                return BadRequest();
            }


            try
            {
                _productFamilyRepository.Update(productFamily);
                await _productFamilyRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductFamilyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ProductFamily/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productFamily = await _productFamilyRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (productFamily == null)
            {
                return NotFound();
            }

            _productFamilyRepository.Delete(productFamily);
            await _productFamilyRepository.SaveAsync();

            return Ok(productFamily);
        }

        private bool ProductFamilyExists(int id)
        {
            return _productFamilyRepository.Any(a => a.Id.Equals(id));
        }
    }
}