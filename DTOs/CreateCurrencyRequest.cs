using System.ComponentModel.DataAnnotations;
namespace AttineosCurrency.DTOs;

public class CreateCurrencyRequest
{
     [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string Symbol { get; set; } = string.Empty;
    [Required]
     [Range(0.000001, double.MaxValue)]
    public decimal Price { get; set; }
    [Range(0, double.MaxValue)]
    public decimal MarketCap { get; set; }
}