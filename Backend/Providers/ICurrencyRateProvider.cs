namespace Backend.Providers;

public interface ICurrencyRateProvider
{
    Task<List<decimal>> GetLastEuroRatesAsync(int numOfDays);
}