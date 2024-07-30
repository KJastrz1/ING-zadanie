namespace Shared.Contract.Responses;

public record CurrencyStatisticsResponse(
    string Currency,
    int NumOfDays,
    decimal Average,
    decimal Min,
    decimal Max
);