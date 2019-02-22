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
    public class VendorController : ControllerBase
    {
        public readonly IRepositoryBase<Vendor> _vendorRepository;

        public VendorController(IRepositoryBase<Vendor> context)
        {
            _vendorRepository = context;
        }

        // POST: api/Vendor
        [HttpPost]
        public async Task<IActionResult> PostVendor([FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _vendorRepository.Add(vendor);
            await _vendorRepository.SaveAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // GET: api/Vendor
        [HttpGet]
        public IEnumerable<Vendor> GetVendors()
        {
            return _vendorRepository.GetAll();
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _vendorRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }


        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor([FromRoute] int id, [FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor.Id)
            {
                return BadRequest();
            }


            try
            {
                _vendorRepository.Update(vendor);
                await _vendorRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
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

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _vendorRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            _vendorRepository.Delete(vendor);
            await _vendorRepository.SaveAsync();

            return Ok(vendor);
        }

        private bool VendorExists(int id)
        {
            return _vendorRepository.Any(a => a.Id.Equals(id));
        }


    }
}