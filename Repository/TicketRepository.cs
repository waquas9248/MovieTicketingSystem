using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class TicketRepository: ITicketRepository
{
    public async Task<Ticket> GetTicketFromSeatAndShowing(int seatId, int showingId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { SeatId = seatId, ShowingId = showingId };
        var query = "select * from TICKET where showingId = @ShowingId and SeatId = @SeatId";       
        return await connection.QueryFirstOrDefaultAsync<Ticket>(query, parameters);
    }

    public async Task<bool> MarkTicketReserved(int ticketId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { TicketId = ticketId };
        var query = "UPDATE TICKET SET Reserved = 1 WHERE TicketId = @TicketId";
        var result = await connection.ExecuteAsync(query, parameters);
        return result > 0;
    }

    public async Task<Ticket> GetTicketById(int ticketId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { TicketId = ticketId };
        var query = "select * from TICKET where ticketId = @TicketId";
        return await connection.QueryFirstOrDefaultAsync<Ticket>(query, parameters);
    }
}
