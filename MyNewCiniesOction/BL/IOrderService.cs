using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrder();
        public Task<List<User>> GetUsers();
        public Task<User> GetDetailsByUserId(int userId);
        public Task<Order> GetOrderById(int orderId);
        public Task<List<Order>> GetOrderByUserId(int userId);
        public Task<int> Post(Order order);
        public Task<int> GetIncomes();
    }
}
