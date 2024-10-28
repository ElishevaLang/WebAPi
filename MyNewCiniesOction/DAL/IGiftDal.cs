using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IGiftDal
    {
        public Task<List<Gift>> Get();
        public Task<bool> Delete(int giftId);
        public Task<bool> Put(Gift gift);
        public Task<bool> Post(Gift gift);
        public Task<List<Gift>> GetByName(string name);
        public Task<List<Gift>> GetByDonorId(int donorId);
        public Task<int> GetNumOfOrders(int giftId);
        public Task<Gift> GetMostExpensiveGift();
        public Task<List<Gift>> GetByCategory(string categoryName);
        public Task<List<Gift>> GetGiftWithNumOfOrders(int num);
        public Task<List<Gift>> OrderByPrice();
        public Task<List<Gift>> OrderByPurchas();
        public Task<List<Gift>> GetById( int giftId);
    }//public Task<List<Object>> GetGiftDonor();
    
}
