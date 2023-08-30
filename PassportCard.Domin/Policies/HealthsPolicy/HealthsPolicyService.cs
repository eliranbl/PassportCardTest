using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PassportCard.Domain.Policies.HealthsPolicy;

/// <summary>
/// Health policy service.
/// </summary>
public class HealthsPolicyService : IPolicyService
{
    private readonly HealthPolicy _healthPolicy;
    private readonly ILogger<HealthsPolicyService> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="healthPolicy">Health policy.</param>
    /// <param name="logger">Logger.</param>
    public HealthsPolicyService(IOptions<HealthPolicy> healthPolicy, ILogger<HealthsPolicyService> logger)
    {
        _healthPolicy = healthPolicy.Value;
        _logger = logger;
    }

    /// <summary>
    /// Get Rate.
    /// </summary>
    /// <returns>Decimal.</returns>
    public decimal GetRate()
    {
        decimal rating = 0;
        _logger.LogInformation("Rating HEALTH policy...");
        _logger.LogInformation("Validating policy.");
        if (string.IsNullOrEmpty(_healthPolicy.Gender))
        {
            _logger.LogError("Health policy must specify Gender");
            return rating;
        }
        if (_healthPolicy.Gender == "Male")
        {
            if (_healthPolicy.Deductible < 500)
            {
                rating = 1000m;
            }
            rating = 900m;
        }
        else
        {
            if (_healthPolicy.Deductible < 800)
            {
                rating = 1100m;
            }
            rating = 1000m;
        }

        return rating;
    }
}