using AttineosCurrency.Data;
using AttineosCurrency.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttineosCurrency.Repositories;

public class AttineosCurrencyRepository : IAttineosCurrencyRepository
{
    private readonly AppDbContext _context;

    public AttineosCurrencyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Currency>> GetAllCurrenciesAsync()
    {
        return await _context.AttineosCurrencies.ToListAsync();
    }

    public async Task<Currency?> GetCurrencyByIdAsync(int id)
    {
        return await _context.AttineosCurrencies.FindAsync(id);
    }

    public async Task<Currency> CreateCurrencyAsync(Currency currency)
    {
        _context.AttineosCurrencies.Add(currency);
        await _context.SaveChangesAsync();

        return currency;
    }

    public async Task<Currency?> UpdateCurrencyAsync(int id, Currency currency)
    {
        var existingCurrency = await _context.AttineosCurrencies.FindAsync(id);

        if (existingCurrency is null)
            return null;

        existingCurrency.Name = currency.Name;
        existingCurrency.Symbol = currency.Symbol;
        existingCurrency.Price = currency.Price;
        existingCurrency.MarketCap = currency.MarketCap;

        await _context.SaveChangesAsync();

        return existingCurrency;
    }

    public async Task<bool> DeleteCurrencyAsync(int id)
    {
        var currency = await _context.AttineosCurrencies.FindAsync(id);

        if (currency is null)
            return false;

        _context.AttineosCurrencies.Remove(currency);
        await _context.SaveChangesAsync();

        return true;
    }
}