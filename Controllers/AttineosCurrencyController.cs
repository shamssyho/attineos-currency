using AttineosCurrency.Entities;
using AttineosCurrency.Services;
using Microsoft.AspNetCore.Mvc;
using AttineosCurrency.DTOs;

namespace AttineosCurrency.Controllers;

[ApiController]
[Route("api/currencies")]
[Produces("application/json")]
public class AttineosCurrencyController : ControllerBase
{
    private readonly IAttineosCurrencyService _service;

    public AttineosCurrencyController(IAttineosCurrencyService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Currency>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Currency>>> GetAll()
    {
        var currencies = await _service.GetAllCurrenciesAsync();
        return Ok(currencies);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Currency), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Currency>> GetById(int id)
    {
        var currency = await _service.GetCurrencyByIdAsync(id);

        if (currency is null)
            return NotFound();

        return Ok(currency);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Currency), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Currency>> Create([FromBody] CreateCurrencyRequest request)
{
    var currency = new Currency
    {
        Name = request.Name,
        Symbol = request.Symbol,
        Price = request.Price,
        MarketCap = request.MarketCap
    };

    var createdCurrency = await _service.CreateCurrencyAsync(currency);

    return CreatedAtAction(
        nameof(GetById),
        new { id = createdCurrency.Id },
        createdCurrency
    );
}

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Currency), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Currency>> Update(int id, [FromBody] Currency currency)
    {
        var updatedCurrency = await _service.UpdateCurrencyAsync(id, currency);

        if (updatedCurrency is null)
            return NotFound();

        return Ok(updatedCurrency);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteCurrencyAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}