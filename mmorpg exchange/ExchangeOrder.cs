namespace mmorpg_exchange;

public abstract class ExchangeOrder
{
    
}

public class LimitOrder : ExchangeOrder
{
    public bool IsBuyOrder;
    public int Limit;
    
    public Item Item;
    public int Quantity;
    
    public DateTime PostTime;
    public IExchangeUser Owner;

    public int QuantityFulfilled;

    public void Fulfill(LimitOrder fulfillmentOrder)
    {
        if (IsBuyOrder == fulfillmentOrder.IsBuyOrder) return;
        // buy order
        
        
    }
}