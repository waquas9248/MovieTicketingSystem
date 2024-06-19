using Theater.DBModels;
using Theater.Repository;
using Theater.ViewModels;

namespace Theater.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly ITicketService ticketService;
    private readonly IConcessionService concessionService;
    private readonly IShowingService showingService;

    public OrderService(IOrderRepository orderRepository, ITicketService ticketService, IConcessionService concessionService, IShowingService showingService)
    {
        this.orderRepository = orderRepository;
        this.ticketService = ticketService;
        this.concessionService = concessionService;
        this.showingService = showingService;
    }

    public async Task<IEnumerable<Order>> GetOrdersForUser(int userId)
    {
        return await orderRepository.GetOrdersForUser(userId);
    }

    public async Task<OrderViewModel> ProcessOrder(int customerId, int seatId, int showingId, List<int> concessionQuantities)
    {
        var orderId = await orderRepository.CreateOrderAndReturnId(customerId);

        var ticket = await ticketService.GetTicketBySeatAndShowing(seatId, showingId);

        await orderRepository.CreateTicketLineItem(ticket.TicketId, orderId, 1);

        var concessions = await concessionService.GetConcessions();
        for (int index = 0; index < concessionQuantities.Count; index++)
        {
            var concession = concessions.ElementAt(index);
            var concessionQuantity = concessionQuantities.ElementAt(index);
            await orderRepository.CreateConcessionLineItem(concession.ConcessionId, orderId, concessionQuantity);
        }

        await ticketService.MarkTicketReserved(ticket.TicketId);

        var concessionLineItemsEnum = await orderRepository.GetConcessionLineItemsForOrder(orderId);
        var concessionLineItems = concessionLineItemsEnum.ToList();
        var ticketLineItemsEnum = await orderRepository.GetTicketLineItemsForOrder(orderId);
        var ticketLineItems = ticketLineItemsEnum.ToList();

        var orderTotal = await CalcOrderTotal(concessionLineItems, ticket);

        var allConcessions = await concessionService.GetConcessions();

        var orderedConcessions = allConcessions.Where(c => concessionLineItems.Any(cli => cli.ConcessionId == c.ConcessionId)).ToList();
        var showing = await showingService.GetShowing(showingId);

        var concessionLines = new List<ConcessionLineOnOrder> { };
        foreach (var lineItem in concessionLineItems)
        {
            var concession = allConcessions.Where(c => c.ConcessionId == lineItem.ConcessionId).First();
            var concessionLineOrder = new ConcessionLineOnOrder
            {
                ConcessionName = concession.Name,
                Quantity = lineItem.Quantity,
                Total = concession.Price * lineItem.Quantity,
                ConcessionPrice = concession.Price,
            };
            concessionLines.Add(concessionLineOrder);
        }

        var orderModel = new OrderViewModel { OrderId = orderId, Concessions = orderedConcessions, Ticket = ticket, OrderTotal = orderTotal, ShowingDisplay = showing, ConcessionLines = concessionLines };
        return orderModel;
    }

    public async Task<decimal> CalcOrderTotal(List<ConcessionLineItem> concessionLineItems, Ticket ticket)
    {
        var concessions = await concessionService.GetConcessions();
        var total = 0m;
        foreach (var lineItem in concessionLineItems)
        {
            var concession = concessions.Where(c => c.ConcessionId == lineItem.ConcessionId).First();
            var lineItemTotal = concession.Price * lineItem.Quantity;
            total += lineItemTotal;
        }

        total += ticket.Price;

        return total;
    }
}
