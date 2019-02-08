using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE.Catalog.Contracts;
using SE.Catalog.Models;
using SE.Catalog.Repository;

namespace SE.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
       public readonly IRepositoryBase<Package> _packageRepository;

        public CatalogContext _catalogContext { get; set; }

        public PackageController(IRepositoryBase<Package> context, CatalogContext catalogContext)
        {
            _packageRepository = context;
            _catalogContext = catalogContext;
        }
       
        // POST: api/Package
        [HttpPost]
        public async Task<IActionResult> PostPackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _packageRepository.Add(package);
            await _packageRepository.SaveAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // GET: api/Package
        [HttpGet]
        public IEnumerable<Package> GetPackages()
        {
            return _packageRepository.GetAll();
        }

        // GET: api/Package/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = await _packageRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }


        // PUT: api/Package/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage([FromRoute] int id, [FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }


            try
            {
                _packageRepository.Update(package);
                await _packageRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // DELETE: api/Package/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = await _packageRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (package == null)
            {
                return NotFound();
            }

            _packageRepository.Delete(package);
            await _packageRepository.SaveAsync();

            return Ok(package);
        }

        private bool PackageExists(int id)
        {
           return _packageRepository.Any(a => a.Id.Equals(id));
        }


    }

}