using Microsoft.Extensions.Options;
using PassportCard.Domain.Policies;

namespace PassportCard.Domain.RatingEngines;

/// <summary>
/// Rate engine.
/// </summary>
public class RatingEngine : IRatingEngine
{
    private readonly  GeneralPolicy _generalPolicy;
    private readonly IPolicyServiceFactory _policyServiceFactory;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="generalPolicy">General policy.</param>
    /// <param name="policyServiceFactory">Policy service factory.</param>
    public RatingEngine(IOptions<GeneralPolicy> generalPolicy, IPolicyServiceFactory policyServiceFactory)
    {
        _policyServiceFactory = policyServiceFactory;
        _generalPolicy = generalPolicy.Value;
    }

    /// <summary>
    /// Get rate data.
    /// </summary>
    /// <returns>Decimal.</returns>
    public decimal GetRateData()
    {
        return _policyServiceFactory.CreateService(_generalPolicy.Type).GetRate();
    }
}