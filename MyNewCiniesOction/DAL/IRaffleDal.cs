using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IRaffleDal
    {
        public Task<bool> InsertWinningToRaffle(int userId, int giftId);
        public Task<List<RaffleDTO>> Winners();

    }
}
