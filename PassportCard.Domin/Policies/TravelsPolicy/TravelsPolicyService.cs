using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PassportCard.Domain.Policies.TravelsPolicy;

/// <summary>
/// Travel Policy service.
/// </summary>
public class TravelsPolicyService : IPolicyService
{
    private readonly TravelPolicy _travelPolicy;
    private readonly ILogger<TravelsPolicyService> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="travelPolicy">Travel policy.</param>
    /// <param name="logger">Logger.</param>
    public TravelsPolicyService(IOptions<TravelPolicy> travelPolicy, ILogger<TravelsPolicyService> logger)
    {
        _logger = logger;
        _travelPolicy = travelPolicy.Value;
    }

    /// <summary>
    /// Get Rate.
    /// </summary>
    /// <returns>Decimal.</returns>
    public decimal GetRate()
    {
        decimal rating = 0;

        _logger.LogInformation("Rating TRAVEL policy...");
        _logger.LogInformation("Validating policy.");

        switch (_travelPolicy.Days)
        {
            case <= 0:
                _logger.LogError("Travel policy must specify Days.");
                return rating;
            case > 180:
                _logger.LogError("Travel policy cannot be more then 180 Days.");
                return rating;
        }

        if (string.IsNullOrEmpty(_travelPolicy.Country))
        {
            _logger.LogError("Travel policy must specify country.");
            return rating;
        }

        rating = _travelPolicy.Days * 2.5m;

        if (_travelPolicy.Country == "Italy")
            rating *= 3;

        return rating;
    }
}