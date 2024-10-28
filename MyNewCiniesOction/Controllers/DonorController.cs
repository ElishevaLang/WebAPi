using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DonorController:Controller
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpGet]
        public async Task<List<Donor>> Get()
        {
            try
            {
                return await _donorService.GetDonors();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<bool> PostDonor(DonorDTO donor)
        {
            try
            {
                return await _donorService.PostDonor(donor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<bool> DeleteDonor([FromQuery] int donorId)
        {
            try
            {
                return await _donorService.DeleteDonor(donorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<bool> UpdateDonor( Donor donor)
        {
            try 
            {
                return await _donorService.UpdateDonor(donor); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("ByName")]
        public async Task<List<Donor>> GetByName(string name)
        {
            try
            {
                return await _donorService.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("ByEmail")]
        public async Task<List<Donor>> GetByEmail(string email)
        {
            try
            {
                 return await _donorService.GetByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetByGift")]
        public async Task<List<Donor>> GetByGift(int giftId)
        {
            try
            {
                return await _donorService.GetByGift(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
