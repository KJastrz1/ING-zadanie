using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet("eur/statistics")]
    public async Task<IActionResult> GetEuroStatistics(int numOfDays = 20)
    {
        var statistics = await _currencyService.GetEuroStatisticsAsync(numOfDays);
        return Ok(statistics);
    }
}