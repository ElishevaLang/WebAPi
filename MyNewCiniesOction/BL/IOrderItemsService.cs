using MyNewCiniesOction.DTO;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.BL
{
    public interface IOrderItemsService
    {
        public Task<List<OrderItemsGetDTO>> GetOrderItems();

        public Task<bool> PostOrderItems(OrderItems orderItems);
        public Task<List<OrderItems>> GetOrderItemsByUser(int userId);
        public Task<int> PostOrderItemsList(List<CartDTO> itemsList, int orderId);
        public Task<List<OrderItemsGetDTO>> GetPurchasOfGift(int giftId);

    }
}
