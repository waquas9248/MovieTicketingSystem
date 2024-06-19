using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class OrderRepository : IOrderRepository
{
    public async Task<int> CreateOrderAndReturnId(int customerId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);

        var nextOrderIdQuery = "SELECT MAX(OrderId) FROM CUSTOMER_ORDER";
        var maxOrderId = await connection.QueryFirstOrDefaultAsync<int?>(nextOrderIdQuery) ?? 0;

        var parameters = new { CustomerId = customerId, OrderId = maxOrderId + 1 };
        var query = "INSERT INTO CUSTOMER_ORDER (OrderId, CustomerId) VALUES (@OrderId, @CustomerId);";
        
        var insertResult = await connection.ExecuteAsync(query, parameters);
        return maxOrderId;
    }

    public async Task<bool> CreateTicketLineItem(int ticketId, int orderId, int quantity)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);

        var nextTicketLineItemIdQuery = "SELECT MAX(TicketLineItemId) FROM TICKET_LINE_ITEM";
        var maxTicketLineItemId = await connection.QueryFirstOrDefaultAsync<int?>(nextTicketLineItemIdQuery) ?? 0;

        var query = "INSERT INTO TICKET_LINE_ITEM (TicketLineItemId, TicketId, OrderId, Quantity) VALUES (@TicketLineItemId, @TicketId, @OrderId, @Quantity);";
        var parameters = new { TicketLineItemId = maxTicketLineItemId + 1, TicketId = ticketId, OrderId = orderId , Quantity = quantity};
        
        var result = await connection.ExecuteAsync(query, parameters);
        return result > 0;
    }

    public async Task<bool> CreateConcessionLineItem(int concessionId, int orderId, int quantity)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);

        var nextConcessionLineItemIdQuery = "SELECT MAX(ConcessionLineItemId) FROM CONCESSION_LINE_ITEM";
        var maxConcessionLineItemId = await connection.QueryFirstOrDefaultAsync<int?>(nextConcessionLineItemIdQuery) ?? 0;

        var query = "INSERT INTO CONCESSION_LINE_ITEM (ConcessionLineItemId, ConcessionId, OrderId, Quantity) VALUES  " +
            "(@ConcessionLineItemId, @ConcessionId, @OrderId, @Quantity);";

        var parameters = new { ConcessionLineItemId = maxConcessionLineItemId + 1, ConcessionId = concessionId, OrderId = orderId, Quantity = quantity };
        var result = await connection.ExecuteAsync(query, parameters);
        return result > 0;
    }

    public async Task<IEnumerable<TicketLineItem>> GetTicketLineItemsForOrder(int orderId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { OrderId = orderId };
        var query = "select * from TICKET_LINE_ITEM where OrderId = @OrderId;";
        return await connection.QueryAsync<TicketLineItem>(query, parameters);
    }

    public async Task<IEnumerable<ConcessionLineItem>> GetConcessionLineItemsForOrder(int orderId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { OrderId = orderId };
        var query = "select * from CONCESSION_LINE_ITEM where OrderId = @OrderId;";
        return await connection.QueryAsync<ConcessionLineItem>(query, parameters);
    }

    public async Task<IEnumerable<Order>> GetOrdersForUser(int userId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { UserId = userId };
        var query = "select * from CUSTOMER_ORDER where UserId = @UserId;";
        return await connection.QueryAsync<Order>(query, parameters);
    }
}
