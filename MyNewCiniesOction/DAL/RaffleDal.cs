using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public class RaffleDal : IRaffleDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;

        public RaffleDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }
 

        public async Task<bool> InsertWinningToRaffle(int userId, int giftId)
        {

            try
            {
                if (userId == null || giftId == null)
                {
                    return false;
                }
                Raffle raffle = new Raffle(userId, giftId);
                await _chiniesOctionContext.Raffle.AddAsync(raffle);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<RaffleDTO>> Winners()
        {
            try
            {
                List<RaffleDTO> raffleList = await _chiniesOctionContext.Raffle
                .Select(o => new RaffleDTO {RaffleId=o.RaffleId, RaffleDate=o.RaffleDate, Gift = o.Gift,User = o.User}).ToListAsync();
                return raffleList;
                //return await _chiniesOctionContext.Raffle.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
