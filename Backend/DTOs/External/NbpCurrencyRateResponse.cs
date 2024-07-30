namespace Backend.DTOs.External;

public record NbpCurrencyRateResponse(
    string Table,
    string Currency,
    string Code,
    List<Rate> Rates
);

public record Rate(
    string No,
    DateTime EffectiveDate,
    decimal Mid
);