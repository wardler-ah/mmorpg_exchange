namespace mmorpg_exchange;

public class ExchangeOrder
{
    public bool IsBuyOrder;

    public Item Item;
    public int Limit;
    public Dictionary<CurrencyItem, int> CurrencyLimits;

    public int Quantity;
    public DateTime PostTime;
    public IExchangeUser Owner;
}