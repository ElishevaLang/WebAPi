using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Migrations;
using MyNewCiniesOction.Models;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MyNewCiniesOction.DAL
{
    public class GiftDal : IGiftDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public GiftDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }

        public async Task<bool> Delete(int giftId)
        {
            try {
            var gift = await _chiniesOctionContext.Gift.FindAsync(giftId);
            if (gift == null)
            {
                return false;
            }

            _chiniesOctionContext.Gift.Remove(gift);
            await _chiniesOctionContext.SaveChangesAsync();

            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Gift>> Get()
        {
            try {
                List<Gift> listGift = await _chiniesOctionContext.Gift
                .Select(g => new Gift
                {
                    GiftId = g.GiftId,
                    GiftName = g.GiftName,
                    Category = g.Category,
                    CategoryId = g.CategoryId,
                    GiftDescription = g.GiftDescription,
                    GiftImage = g.GiftImage,
                    GiftPrice = g.GiftPrice
                })
                  .ToListAsync();
                return listGift;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Post(Gift gift)
        {
            try { 
            if (gift == null)
            {
                return false;
            }

             _chiniesOctionContext.Gift.AddAsync(gift);
            await _chiniesOctionContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Put(Gift gift)
        {
            try { 
            var d = _chiniesOctionContext.Gift.Where(gif => gif.GiftId == gift.GiftId).First();
            if(d==null)
            {
                return false;
            }
            d.GiftName = gift.GiftName;
            d.Category = gift.Category;
            d.GiftDescription = gift.GiftDescription;
            d.GiftPrice = gift.GiftPrice;
            d.GiftImage = gift.GiftImage;

            _chiniesOctionContext.Gift.Update(d);
             await _chiniesOctionContext.SaveChangesAsync();
            return true;
        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //================================
        public async Task<List<Gift>> GetByName(string name)
        {
            try {

                List<Gift> tmp = await _chiniesOctionContext.Gift
                .Where(e => e.GiftName.StartsWith(name))
                .ToListAsync();

                return tmp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Gift>> GetByDonorId(int donorId)
        {
            try { 
            return await _chiniesOctionContext.Donation
                    .Include(g => g.Gift)
                    .Where(gift => gift.DonorId == donorId)
                    .Select(donation => donation.Gift)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Gift>> GetById(int giftId)
        {
            try
            {
                return await _chiniesOctionContext.Gift
                        .Where(gift => gift.GiftId == giftId)
                        .Select(gift => gift)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetNumOfOrders(int giftId)
        {
            try { 
                var gift= _chiniesOctionContext.OrderItems.Where(g => g.GiftId == giftId).ToList();
                return gift.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Gift>> GetGiftWithNumOfOrders(int num)
        {
            try
            {
                    return await _chiniesOctionContext.OrderItems
                    .Include(g => g.Gift)
                    .GroupBy(o => o.GiftId)
                    .Where(g=>g.Count() == num)
                    .Select(g => g.First().Gift)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Gift> GetMostExpensiveGift()
        {
            try {
            int max = _chiniesOctionContext.Gift.Max(g => g.GiftPrice);
            Gift maxGift =await _chiniesOctionContext.Gift.FirstOrDefaultAsync(g => g.GiftPrice==max);
            return maxGift;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Gift>> GetByCategory(string categoryName)
        {
            try
            {
                List<Gift> gift = await _chiniesOctionContext.Gift.Where(g => g.Category.CategoryName == categoryName).ToListAsync();
                return gift;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public async Task<List<Gift>> OrderByPrice()
        {
            try
            {
                List<Gift> gift = await _chiniesOctionContext.Gift
                    .OrderByDescending(g => g.GiftPrice)
                    .ToListAsync();
                return gift;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Gift>> OrderByPurchas()
        {
            try
            {
                List<Gift> gift = await _chiniesOctionContext.OrderItems
                    .Include(g=>g.Gift)
                    .GroupBy(g=>g.GiftId)
                    .OrderByDescending(g => g.Count())
                    .Select(g=>g.First().Gift)
                    .ToListAsync();
                return gift;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
