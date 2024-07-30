using Newtonsoft.Json;
using Backend.DTOs.External;
using Backend.Exceptions;

namespace Backend.Providers;

public class NbpCurrencyRateProvider : ICurrencyRateProvider
{
    private readonly HttpClient _httpClient;

    public NbpCurrencyRateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<decimal>> GetLastEuroRatesAsync(int numOfDays)
    {
        var url = $"http://api.nbp.pl/api/exchangerates/rates/a/eur/last/{numOfDays}/?format=json";
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new ExternalServiceException();
        }

        var content = await response.Content.ReadAsStringAsync();
        var nbpData = JsonConvert.DeserializeObject<NbpCurrencyRateResponse>(content);
       
        if (nbpData?.Rates == null)
        {
            throw new ExternalServiceException();
        }
        
        var rates = new List<decimal>();

        foreach (var rate in nbpData.Rates)
        {
            rates.Add(rate.Mid);
        }

        return rates;
    }
}
