using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.IdentityModel.Protocols;
using MyNewCiniesOction.BL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GiftController : Controller
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService= giftService;
        }

        [HttpGet]
        public async  Task<List<Gift>> Get()
        {
            try
            {
               return await _giftService.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getById")]
        public async Task<List<Gift>> GetById(int giftId)
        {
            try
            {
                return await _giftService.GetById(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]

        public async Task<bool> Delete(int giftId)
        {
            try
            {
                return await _giftService.Delete(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<bool> Put(GiftDTO gift)
        {
            try
            {
                return await _giftService.Put(gift);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<bool> Post(GiftDTO gift)
        {
            try
            {
                return await _giftService.Post(gift);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("/getByGiftName")]
        [Authorize(Roles = "admin")]
        public async Task<List<GiftDTO>> GetByName(string name)
        {
            try
            {
                return await _giftService.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet ("/getByDonorId")]
        public async Task<List<GiftDTO>> GetByDonorId(int donorId)
        {
            try
            {
                return await _giftService.GetByDonorId(donorId);
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("/numOfOrders")]
        public async Task<int> GetNumOfOrders(int giftId)
        {
            try
            {
                return await _giftService.GetNumOfOrders(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("/getMostExpensiveGift")]
        public async Task<GiftDTO> GetMostExpensiveGift()
        {
            try
            {
                return await _giftService.GetMostExpensiveGift();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("/getByCategory")]
        public async Task<List<GiftDTO>> GetByCategory(string categoryName)
        {
            try
            {
               return await _giftService.GetByCategory(categoryName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpGet("/getByNumOfOrders")]
        public async Task<List<GiftDTO>> GetGiftWithNumOfOrders(int num)
        {
            try
            {
                return await _giftService.GetGiftWithNumOfOrders(num);
            }
             catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("/orderByPrice")]
        public async Task<List<GiftDTO>> OrderByPrice()
        {
            try
            {
                return await _giftService.OrderByPrice();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet("/orderByPurchas")]
        public async Task<List<GiftDTO>> OrderByPurchas()
        {
            try
            {
                return await _giftService.OrderByPurchas();
            }
             catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}