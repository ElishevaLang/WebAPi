using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface IRaffleService
    {
        public Task<bool> RaffleForEachGift();
        public Task<List<RaffleDTO>> Winners();

    }
}
