using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface IDonorService
    {
        public Task<List<Donor>> GetDonors();
        public Task<bool> PostDonor(DonorDTO donor);
        public Task<bool> DeleteDonor(int donorId);//int id
        public Task<bool> UpdateDonor(Donor donor);
        public Task<List<Donor>> GetByName(string name);
        public Task<List<Donor>> GetByEmail(string email);
        public Task<List<Donor>> GetByGift(int giftId);
    }
}
