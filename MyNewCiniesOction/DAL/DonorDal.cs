using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public class DonorDal:IDonorDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public DonorDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }
        //=================================================
        public async Task<List<Donor>> GetDonors()
        {
            try { 
            return await _chiniesOctionContext.Donor.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> PostDonor(Donor d)
        {
            try {
            await _chiniesOctionContext.Donor.AddAsync(d);
            await _chiniesOctionContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteDonor(int donorId)
        {
            try {
            var donor = await _chiniesOctionContext.Donor.FindAsync(donorId);
            if (donor == null)
            {
                return false;
            }

            _chiniesOctionContext.Donor.Remove(donor);
            await _chiniesOctionContext.SaveChangesAsync();

            return true;
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateDonor(Donor donor)
        {
            try {
                var d = _chiniesOctionContext.Donor.Where(don => don.DonorId == donor.DonorId).First();

                d.DonorFirstName = donor.DonorFirstName;
                d.DonorLastName = donor.DonorLastName;
                d.DonorEmail = donor.DonorEmail;

                _chiniesOctionContext.Donor.Update(d);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    //======================================================
        public async Task<List<Donor>> GetByGift(int giftId)
        {
            try { 
            return await _chiniesOctionContext.Donation
                    .Include(d => d.Donor)
                    .Where(don => don.GiftId == giftId)
                    .Select(donation => donation.Donor)
                    .ToListAsync();
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
        public async Task<List<Donor>> GetByEmail(string email)
        {
            try { 
            List<Donor> tmp = await _chiniesOctionContext.Donor.Where(e => e.DonorEmail == email).ToListAsync();
            if (tmp != null)
            {
                return tmp;
            }
            else
            {
                return null;//============================
            }
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Donor>> GetByName(string name)
        {
            try { 
            List<Donor> tmp = await _chiniesOctionContext.Donor.Where(e => e.DonorFirstName.StartsWith(name) || e.DonorLastName.StartsWith(name)).ToListAsync();
            return tmp;
        }
            catch (Exception ex)
            {
                throw ex;
            }
        } //======================================================
        public async Task<List<Donor>> GetDonationByGift(int giftId)//    XXX
        {
            return await _chiniesOctionContext.Donation
                    .Include(d => d.Donor)
                    //.ThenInclude(g => g.Gift)

                    //.ThenInclude(don => don.DonorId)
                    .Where(don => don.GiftId == giftId)
                    //.Select(d => d.Donor)
                    .Select(donation => donation.Donor)
                    .ToListAsync();


            List<Donor> donors = new List<Donor>();
            return donors;
        }


    }
}
