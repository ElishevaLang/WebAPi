using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Models;
using System.ComponentModel.DataAnnotations;

namespace MyNewCiniesOction.DAL
{
    public class UserDal : IUserDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public UserDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }

        public async Task<bool> Delete(int userId)
        {
            try {
                var user = await _chiniesOctionContext.User.FindAsync(userId);
                if (user == null)
                {
                    return false;
                }

                _chiniesOctionContext.User.Remove(user);
                await _chiniesOctionContext.SaveChangesAsync();

                return true;
            
            }  catch (Exception ex)
            {
                throw ex;
            }
}

        public async Task<List<User>> Get()
        {
            try {
            return await _chiniesOctionContext.User.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Post(User user)
        {
            try { 
            if (user == null)
            {
                return false;
            }

            await _chiniesOctionContext.User.AddAsync(user);
            await _chiniesOctionContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> PutForUser(User user)
        {
            try
            {
                var u = _chiniesOctionContext.User.Where(u => u.UserId == user.UserId).First();
                if (u == null)
                {
                    return false;
                }
                //d.UserId = user.UserId;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Password = user.Password;
                u.UserPhone = user.UserPhone;
                u.UserEmail = user.UserEmail;
                u.UserPhone = user.UserPhone;

                _chiniesOctionContext.User.Update(u);
                await _chiniesOctionContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            //======================================================
            public async Task<bool> PutForAdmin(User user)
        {
            try { 
            var u = _chiniesOctionContext.User.Where(u => u.UserId == user.UserId).First();
            if (u == null)
            {
                return false;
            }
            //d.UserId = user.UserId;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Password = user.Password;
            u.UserPhone = user.UserPhone;
            u.UserEmail = user.UserEmail;
            u.UserPhone = user.UserPhone;
            u.UserIsAdmin = user.UserIsAdmin;  
           _chiniesOctionContext.User.Update(u);
            await _chiniesOctionContext.SaveChangesAsync();
            return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            return await _chiniesOctionContext.User.Where(p => p.UserEmail == email && p.Password == password).FirstOrDefaultAsync();


        }
    }
}
