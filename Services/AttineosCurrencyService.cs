using AttineosCurrency.Entities;
using AttineosCurrency.Repositories;

namespace AttineosCurrency.Services;

public class AttineosCurrencyService : IAttineosCurrencyService
{
    private readonly IAttineosCurrencyRepository _repository;

    public AttineosCurrencyService(IAttineosCurrencyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Currency>> GetAllCurrenciesAsync()
    {
        return await _repository.GetAllCurrenciesAsync();
    }

    public async Task<Currency?> GetCurrencyByIdAsync(int id)
    {
        return await _repository.GetCurrencyByIdAsync(id);
    }

    public async Task<Currency> CreateCurrencyAsync(Currency currency)
    {
        currency.CreatedAt = DateTime.UtcNow;

        return await _repository.CreateCurrencyAsync(currency);
    }

    public async Task<Currency?> UpdateCurrencyAsync(int id, Currency currency)
    {
        var existingCurrency = await _repository.GetCurrencyByIdAsync(id);

        if (existingCurrency is null)
            return null;

        existingCurrency.Name = currency.Name;
        existingCurrency.Symbol = currency.Symbol;
        existingCurrency.Price = currency.Price;
        existingCurrency.MarketCap = currency.MarketCap;

        return await _repository.UpdateCurrencyAsync(id, existingCurrency);
    }

    public async Task<bool> DeleteCurrencyAsync(int id)
    {
        var existingCurrency = await _repository.GetCurrencyByIdAsync(id);

        if (existingCurrency is null)
            return false;

        return await _repository.DeleteCurrencyAsync(id);
    }
}