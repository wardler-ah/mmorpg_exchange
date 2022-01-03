﻿namespace mmorpg_exchange;

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

public struct ExchangeOrder
{
    public bool IsBuyOrder;

    public Item Item;
    public int Limit;
    public Dictionary<CurrencyItem, int> CurrencyLimits;

    public int Quantity;
    public DateTime PostTime;
    public IExchangeUser Owner;
}

public interface IExchangeUser
{
    
}