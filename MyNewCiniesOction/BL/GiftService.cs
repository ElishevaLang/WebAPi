using AutoMapper;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Migrations;
using MyNewCiniesOction.Models;
using System;
using System.Collections.Generic;

namespace MyNewCiniesOction.BL
{
    public class GiftService : IGiftService
    {
        private readonly IGiftDal _giftDal;
        IMapper _mapper;
        public GiftService(IGiftDal giftDal,IMapper mapper)
        {
            _giftDal = giftDal;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int giftId)
        {
            return await _giftDal.Delete(giftId);
        }

        public async Task<List<Gift>> Get()
        {
          return await _giftDal.Get();

        }
        public async Task<List<Gift>> GetById(int giftId)
        {
            return await _giftDal.GetById( giftId);

        }

        public  async Task<bool> Post(GiftDTO giftDTO)
        {
            Gift gift = _mapper.Map<Gift>(giftDTO);
            return await _giftDal.Post(gift);
        }
        public async Task<bool> Put(GiftDTO giftDTO)
        {
            Gift gift = _mapper.Map<Gift>(giftDTO);
            return await _giftDal.Put(gift);
        }
        public async Task<List<GiftDTO>> GetByName(string name)
        {
            List<Gift> list = await _giftDal.GetByName(name);
            return _mapper.Map<List<GiftDTO>>(list);
        }
        public async Task<List<GiftDTO>> GetByDonorId(int donorId)
        {
            List<Gift> list = await _giftDal.GetByDonorId(donorId);
              return _mapper.Map<List<GiftDTO>>(list);
        }
        public async Task<int> GetNumOfOrders(int giftId)
        {
            return await _giftDal.GetNumOfOrders(giftId);
        }
        public async Task<GiftDTO> GetMostExpensiveGift()

        {
            Gift gift = await _giftDal.GetMostExpensiveGift();
            return _mapper.Map<GiftDTO>(gift);
        }
        public async Task<List<GiftDTO>> GetByCategory(string categoryName)
        {
            List<Gift> list = await _giftDal.GetByCategory(categoryName);
            return _mapper.Map<List<GiftDTO>>(list);
        }
        public async Task<List<GiftDTO>> GetGiftWithNumOfOrders(int num)
        {
            List<Gift> list = await _giftDal.GetGiftWithNumOfOrders(num);
            return _mapper.Map<List<GiftDTO>>(list);
        }
        public async Task<List<GiftDTO>> OrderByPrice()
        {
            List<Gift> list = await _giftDal.OrderByPrice();
            return _mapper.Map<List<GiftDTO>>(list);
        }
        public async Task<List<GiftDTO>> OrderByPurchas()
        {
            List<Gift> list = await _giftDal.OrderByPurchas();
            return _mapper.Map<List<GiftDTO>>(list);
        }
    }
}
