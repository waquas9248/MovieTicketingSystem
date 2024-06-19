using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public interface IOrderRepository
{
    Task<int> CreateOrderAndReturnId(int customerId);

    Task<bool> CreateTicketLineItem(int ticketId, int orderId, int quantity);

    Task<bool> CreateConcessionLineItem(int concessionId, int orderId, int quantity);

    Task<IEnumerable<TicketLineItem>> GetTicketLineItemsForOrder(int orderId);

    Task<IEnumerable<ConcessionLineItem>> GetConcessionLineItemsForOrder(int orderId);

   Task<IEnumerable<Order>> GetOrdersForUser(int userId);
}
