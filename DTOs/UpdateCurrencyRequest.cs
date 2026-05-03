using System.ComponentModel.DataAnnotations;

namespace AttineosCurrency.DTOs;

public class UpdateCurrencyRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string Symbol { get; set; } = string.Empty;

    [Range(0.0001, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue)]
    public decimal MarketCap { get; set; }
}