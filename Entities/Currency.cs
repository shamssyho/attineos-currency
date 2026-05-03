namespace AttineosCurrency.Entities;

public class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal MarketCap { get; set; }

    public DateTime CreatedAt { get; set; }
}