using Theater.DBModels;
using Theater.ViewModels;

namespace Theater.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersForUser(int userId);

    Task<OrderViewModel> ProcessOrder(int customerId, int seatId, int showingId, List<int> concessionQuantities);
}
