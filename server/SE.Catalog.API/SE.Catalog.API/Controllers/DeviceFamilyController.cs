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
    public class DeviceFamilyController : ControllerBase
    {

        private IRepositoryBase<DeviceFamily> _deviceFamilyRepository;
        public DeviceFamilyController(IRepositoryBase<DeviceFamily> context)
        {
            _deviceFamilyRepository = context;
        }

        // POST: api/DeviceFamily
        [HttpPost]
        public async Task<IActionResult> PostProductFamily([FromBody] DeviceFamily deviceFamily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _deviceFamilyRepository.Add(deviceFamily);
            await _deviceFamilyRepository.SaveAsync();

            return CreatedAtAction("GetDeviceFamily", new { id = deviceFamily.Id }, deviceFamily);
        }

        // GET: api/DeviceFamily
        [HttpGet]
        public IEnumerable<DeviceFamily> GetDeviceFamily()
        {
            return _deviceFamilyRepository.GetAll();
        }

        // GET: api/DeviceFamily/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceFamily = await _deviceFamilyRepository.FirstOrDefaultAsync(x => x.Id == id);

            if (deviceFamily == null)
            {
                return NotFound();
            }

            return Ok(deviceFamily);
        }

        // PUT: api/DeviceFamily/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceFamily([FromRoute] int id, [FromBody] DeviceFamily deviceFamily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceFamily.Id)
            {
                return BadRequest();
            }


            try
            {
                _deviceFamilyRepository.Update(deviceFamily);
                await _deviceFamilyRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceFamilyExists(id))
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

        // DELETE: api/DeviceFamily/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceFamily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceFamily = await _deviceFamilyRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (deviceFamily == null)
            {
                return NotFound();
            }

            _deviceFamilyRepository.Delete(deviceFamily);
            await _deviceFamilyRepository.SaveAsync();

            return Ok(deviceFamily);
        }

        private bool DeviceFamilyExists(int id)
        {
            return _deviceFamilyRepository.Any(a => a.Id.Equals(id));
        }

    }
}