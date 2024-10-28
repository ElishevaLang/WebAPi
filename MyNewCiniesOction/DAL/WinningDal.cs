using MyNewCiniesOction.Models;
using Microsoft.EntityFrameworkCore;
namespace MyNewCiniesOction.DAL
{
    public class WinningDal:IWinningDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public WinningDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }

    }
}
