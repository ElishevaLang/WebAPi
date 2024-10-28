using MyNewCiniesOction.DAL;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public async Task<List<Order>> GetOrder()
        {
                return await _orderDal.GetOrders();
           
            //throw new NotImplementedException();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderDal.GetOrderById(orderId);
            //throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrderByUserId(int userId)
        {
            return await _orderDal.GetOrderByUserId(userId);
            //throw new NotImplementedException();
        }

        public async Task<int> Post(Order order)
        {
            return await _orderDal.Post(order);
            //throw new NotImplementedException();
        }
        public async Task<List<User>> GetUsers()
        {
            return await _orderDal.GetUsers();
        }
        public async Task<User> GetDetailsByUserId(int userId)
        {
            return await _orderDal.GetDetailsByUserId(userId);
        }
        public async Task<int> GetIncomes()
        {
            return await _orderDal.GetIncomes();
        }

    }
}
