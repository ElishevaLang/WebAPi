using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IOrderItemsDal
    {
        public Task<List<OrderItemsGetDTO>> GetOrderItems();
      
        public Task<bool> PostOrderItems(OrderItems orderItems);
        public Task<List<OrderItems>> GetOrderItemsByUser(int userId);
        public Task<List<OrderItemsGetDTO>> GetPurchasOfGift(int giftId);
        public Task<int> PostOrderItemsList(List<CartDTO> itemsList, int orderId);
    }
}
