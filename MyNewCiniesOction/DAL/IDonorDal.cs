using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IDonorDal
    {
        public Task<List<Donor>> GetDonors();
        public Task<bool> PostDonor(Donor d);
        public Task<bool> DeleteDonor(int donorId);
        public Task<bool> UpdateDonor(Donor donor);//PutDonor
        public Task<List<Donor>> GetByName(string name);
        public Task<List<Donor>> GetByEmail(string email);
        public Task<List<Donor>> GetByGift(int giftId);
        public Task<List<Donor>> GetDonationByGift(int giftId);

    }
}
