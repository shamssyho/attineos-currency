using AttineosCurrency.Entities;

namespace AttineosCurrency.Repositories;

public interface IAttineosCurrencyRepository
{
    Task<List<Currency>> GetAllCurrenciesAsync();

    Task<Currency?> GetCurrencyByIdAsync(int id);

    Task<Currency> CreateCurrencyAsync(Currency currency);

    Task<Currency?> UpdateCurrencyAsync(int id, Currency currency);

    Task<bool> DeleteCurrencyAsync(int id);
}