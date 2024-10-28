using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IOrderDal
    {
        public Task<List<Order>> GetOrders();
        public Task<List<User>> GetUsers();
        public Task<Order> GetOrderById(int orderId);
        public Task<List<Order>> GetOrderByUserId(int userId);
        public Task<User> GetDetailsByUserId(int userId);
        public Task<int> Post(Order order);
        public Task<int> GetIncomes();
    }
}
