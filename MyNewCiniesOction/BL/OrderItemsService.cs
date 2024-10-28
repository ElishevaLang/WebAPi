using MyNewCiniesOction.DAL;
using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public class OrderItemsService : IOrderItemsService
    { 

        private readonly IOrderItemsDal _orderItemsDal;
       
        public OrderItemsService(IOrderItemsDal orderItemsDal, ICartDal cartDal)
        {
            _orderItemsDal = orderItemsDal;
           ;
        }

        public async Task<List<OrderItemsGetDTO>> GetOrderItems()
        {
            try {
                return await _orderItemsDal.GetOrderItems(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  async Task<bool> PostOrderItems(OrderItems orderItems)
        {
            try {
                return await _orderItemsDal.PostOrderItems(orderItems);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<OrderItems>> GetOrderItemsByUser(int userId)
        {
            try
            {
                return await _orderItemsDal.GetOrderItemsByUser(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> PostOrderItemsList(List<CartDTO> itemsList, int orderId)
        {
            try
            {
                return await _orderItemsDal.PostOrderItemsList(itemsList, orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderItemsGetDTO>> GetPurchasOfGift(int giftId)
        {
            try
            {
                return await _orderItemsDal.GetPurchasOfGift(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
