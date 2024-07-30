using Backend.Providers;
using Backend.Exceptions;
using Shared.Contract.Responses;

namespace Backend.Services;

public class CurrencyService : ICurrencyService
{
    private readonly ICurrencyRateProvider _currencyRateProvider;

    public CurrencyService(ICurrencyRateProvider currencyRateProvider)
    {
        _currencyRateProvider = currencyRateProvider;
    }

    public async Task<CurrencyStatisticsResponse> GetEuroStatisticsAsync(int numOfDays)
    {
        if (numOfDays < 1 || numOfDays > 255)
        {
            throw new CustomApplicationException(
                $"The number of days must be between 1 and 255. Provided value: {numOfDays}.",
                "days_out_of_range");
        }

        var rates = await _currencyRateProvider.GetLastEuroRatesAsync(numOfDays);
        var average = Math.Round(rates.Average(), 4);
        var min = rates.Min();
        var max = rates.Max();

        return new CurrencyStatisticsResponse("euro", numOfDays, average, min, max);
    }
}