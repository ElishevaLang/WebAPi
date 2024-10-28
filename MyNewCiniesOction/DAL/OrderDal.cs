using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.Models;
using System.Xml.Linq;

namespace MyNewCiniesOction.DAL
{
    public class OrderDal : IOrderDal
    {
        private readonly ChiniesOctionContext _chiniesOctionContext;
        public OrderDal(ChiniesOctionContext chiniesOctionContext)
        {
            _chiniesOctionContext = chiniesOctionContext;
        }
        public async Task<List<Order>> GetOrders()
        {
            try
            {
                return await _chiniesOctionContext.Order.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                var o = await _chiniesOctionContext.Order.FindAsync(orderId);
                if (o != null)
                {
                    return o;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Order>> GetOrderByUserId(int userId)
        {
            List<Order> listOrder = await _chiniesOctionContext.Order.Where(o => o.UserId == userId).ToListAsync();
            return listOrder;
        }

        public async Task<int> Post(Order order)
        {
            try
            {
                //order.OrderSum =sum;
                order.OrderDate = DateTime.Now;
                await _chiniesOctionContext.Order.AddAsync(order);
                await _chiniesOctionContext.SaveChangesAsync();
                return order.OrderId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> users = await _chiniesOctionContext.Order
                    .Include(u=>u.User)
                    .GroupBy(o=>o.UserId)
                    .Select(u=>u.First().User)
                    .ToListAsync();
            return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<User> GetDetailsByUserId(int userId)
        {
            try {
                Order o = await _chiniesOctionContext.Order
                     .Include(o => o.User)
                     .FirstOrDefaultAsync(u => u.UserId == userId);
         
                return o.User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetIncomes()
        {
            try
            {
                int sum = await _chiniesOctionContext.Order
                .SumAsync(os => os.OrderSum);
                return sum;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
