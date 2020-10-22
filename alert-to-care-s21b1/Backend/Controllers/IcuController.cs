using System;
using System.Collections.Generic;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/icus")]
    [ApiController]
    public class IcuController : ControllerBase
    {
        private readonly IIcuRepository _icuRepository;

        public IcuController(IIcuRepository icuRepository)
        {
            Console.WriteLine("Icu constructor called");
            this._icuRepository = icuRepository;
        }
        // GET: api/<IcuController>
        [HttpGet]
        public IEnumerable<Models.IcuModel> Get()
        {
            return _icuRepository.GetAllIcu();
        }

        // GET api/<IcuController>/5
        [HttpGet("{id}")]
        public Models.IcuModel Get(string id) => _icuRepository.GetIcu(id);

        // POST api/<IcuController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.IcuModel icu)
        {
            try
            {
                Console.WriteLine("trying to add icu");
                bool isAdded = _icuRepository.AddIcu(icu);
                return Ok(isAdded);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add ICU");
            }
            
        }

        // PUT api/<IcuController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
        }

        // DELETE api/<IcuController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                bool isDeleted = _icuRepository.RemoveIcu(id);
                return Ok(isDeleted);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove ICU");
            }

        }

        /*[HttpGet("beds/availableBeds")]
        public IEnumerable<Models.BedModel> GetAllAvailableBeds()
        {
            return _icuRepository.AvailableBeds();
        }

        [HttpGet("beds/availableBeds/{id}")]
        public IEnumerable<BedModel> GetAvailableBedsInIcu(string icuId)
        {
            return _icuRepository.AvailableBeds(icuId);
        }

        [HttpPost("beds/addBed/{icuId}")]
        public IActionResult AddBed(string icuId)
        {
            try
            {
                string msg = _icuRepository.AddBed(icuId);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpPost("beds/addBed/{icuId}/{location}")]
        public IActionResult AddBedWithLocation(string icuId, string location)
        {
            try
            {
                string msg = _icuRepository.AddBed(icuId,location);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpDelete("beds/remove/{icuId}/{bedId}")]
        public IActionResult RemoveBed(string icuId, string bedId)
        {
            try
            {
                string msg = _icuRepository.RemoveBed(icuId, bedId);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove Bed");
            }

        }*/

    }
}
