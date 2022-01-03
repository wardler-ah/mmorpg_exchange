namespace mmorpg_exchange;

public class Exchange
{
    private List<ExchangeOrder> _exchangeOrders;

    public Exchange()
    {
        _exchangeOrders = new List<ExchangeOrder>();
    }

    public void PostOrder(ExchangeOrder order)
    {
        // try to match first
        if (order.IsBuyOrder)
        {
            var query = from postedOrder in _exchangeOrders
                where order.Owner != postedOrder.Owner
                where order.IsBuyOrder != postedOrder.IsBuyOrder
                where order.Limit <= postedOrder.Limit
                orderby postedOrder.PostTime.Day ascending,
                    postedOrder.PostTime.TimeOfDay ascending
                select postedOrder;

            if (query.Any())
            {
                Console.WriteLine($"Order match found.");
                CancelOrder(query.ElementAt(0));
            }
        }
        
        // if no match, add to orders list
        _exchangeOrders.Add(order);
    }

    public void CancelOrder(ExchangeOrder order)
    {
        _exchangeOrders.Remove(order);
    }
}