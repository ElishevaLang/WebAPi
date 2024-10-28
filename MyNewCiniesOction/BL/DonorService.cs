using AutoMapper;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class DonorService:IDonorService
    {
        private readonly IDonorDal _donorDal;
        IMapper _mapper;
        public DonorService(IDonorDal donorDal, IMapper mapper)
        {
            _donorDal = donorDal;
            _mapper = mapper;
        }
        public async Task<List<Donor>> GetDonors()
        {
            return await _donorDal.GetDonors();
        }

        public async Task<bool> PostDonor(DonorDTO donorDTO)
        {
            Donor donor = _mapper.Map<Donor>(donorDTO);
            return await _donorDal.PostDonor(donor);
        }

        public async Task<bool> DeleteDonor(int donorId)//int id
        {
            return await _donorDal.DeleteDonor(donorId);
        }

        public async Task<bool> UpdateDonor(Donor donor)
        {
            return await _donorDal.UpdateDonor(donor);
        }


        public async Task<List<Donor>> GetByEmail(string email)
        {
            return await _donorDal.GetByEmail(email);
        }

        public async Task<List<Donor>> GetByName(string name)
        {
            return await _donorDal.GetByName(name);
        }

        public async Task<List<Donor>> GetByGift(int giftId)
        {
            return await _donorDal.GetByGift(giftId);
        }
    }
}
