using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.DAL;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class UserService:IUserService
    {
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<bool> Delete(int userId)
        {
            return await _userDal.Delete(userId);
        }

        public async Task<List<User>> Get()
        {
            return await _userDal.Get();
        }

        public Task<bool> Post(User user)
        {
            return _userDal.Post(user);
        }
        public async Task<bool> PutForUser(User user)
        {
            return await _userDal.PutForUser(user);
        }
        public async Task<bool> PutForAdmin(User user)
        {
            return await _userDal.PutForAdmin(user);
        }
        public async Task<User> GetUserByEmailAndPassword( string email,  string password)
        {
            return await _userDal.GetUserByEmailAndPassword(email, password);
        }


    }
}
