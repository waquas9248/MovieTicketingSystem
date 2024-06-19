using Dapper;
using System.Data.SqlClient;
using Theater.DBModels;

namespace Theater.Repository;

public class SeatRepository : ISeatRepository
{
    public async Task<IEnumerable<Ticket>> GetOpenSeatsForShowing(int showingId)
    {
        using var connection = new SqlConnection(ConnectionString.connectionString);
        var parameters = new { ShowingId = showingId };
        var query = @"
select SEAT.SeatId as SeatId, SEAT_TYPE.Type as Type, TICKET.Price as Price
from ticket TICKET
    INNER JOIN seat SEAT ON TICKET.SeatId = SEAT.SeatId
    INNER JOIN seat_type SEAT_TYPE ON SEAT_TYPE.SeatTypeId = SEAT.SeatTypeId
    INNER JOIN showing SHOWING ON TICKET.ShowingId = SHOWING.ShowingId
where SHOWING.ShowingId = @showingId and TICKET.Reserved = 0";
        return await connection.QueryAsync<Ticket>(query, parameters);
    }
}
