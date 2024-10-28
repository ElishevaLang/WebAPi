using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface IGiftService
    {
        public Task<List<Gift>> Get();
        public Task<bool> Delete(int giftId);
        public Task<bool> Put(GiftDTO gift);
        public Task<bool> Post(GiftDTO gift);
        public Task<List<GiftDTO>> GetByName(string name);
        public Task<List<GiftDTO>> GetByDonorId(int donorId);
        public Task<int> GetNumOfOrders(int giftId);
        public Task<GiftDTO> GetMostExpensiveGift();
        public Task<List<GiftDTO>> GetByCategory(string categoryName);
        public Task<List<GiftDTO>> GetGiftWithNumOfOrders(int num);
        public Task<List<GiftDTO>> OrderByPrice();
        public Task<List<GiftDTO>> OrderByPurchas();
        public Task<List<Gift>> GetById(int giftId);
    }
}
