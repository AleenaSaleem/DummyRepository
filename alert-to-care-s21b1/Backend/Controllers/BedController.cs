using System;
using System.Collections.Generic;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/beds")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IBedRepository _bedRepository;
        public BedController(IBedRepository bedRepository)
        {
            this._bedRepository = bedRepository;
        }
        [HttpGet]
        public IEnumerable<Models.BedModel> Get()
        {
            return _bedRepository.AvailableBeds();
        }

        [HttpGet("{id}")]
        public IEnumerable<Models.BedModel> GetAvailableBedsInIcu(string icuId)
        {
            List<Models.BedModel> allBeds= (List<Models.BedModel>)_bedRepository.AvailableBeds();
            return (IEnumerable<Models.BedModel>)allBeds.Find(bed => bed.IcuId == icuId);
        }

        [HttpPost("{icuId}")]
        public IActionResult AddBed(string icuId)
        {
            try
            {
               bool isAdded = _bedRepository.AddBed(icuId);
                return Ok(isAdded);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpPost("{icuId}/{location}")]
        public IActionResult AddBedWithLocation(string icuId, string location)
        {
            try
            {
                bool msg = _bedRepository.AddBed(icuId, location);
                return Ok(msg);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to add Bed");
            }

        }

        [HttpDelete("{icuId}/{bedId}")]
        public IActionResult RemoveBed(string icuId, string bedId)
        {
            try
            {
                bool isDeleted = _bedRepository.RemoveBed(icuId, bedId);
                return Ok(isDeleted);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to remove Bed");
            }

        }
    }
}
