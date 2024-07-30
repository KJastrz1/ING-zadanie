using Backend.DTOs;
using Shared.Contract.Responses;

namespace Backend.Services;

public interface ICurrencyService
{
    Task<CurrencyStatisticsResponse> GetEuroStatisticsAsync(int numOfDays);
}