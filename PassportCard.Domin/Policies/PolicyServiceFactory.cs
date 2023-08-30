using Microsoft.Extensions.DependencyInjection;
using PassportCard.Domain.Policies.HealthsPolicy;
using PassportCard.Domain.Policies.LifeInsurancesPolicy;
using PassportCard.Domain.Policies.TravelsPolicy;

namespace PassportCard.Domain.Policies;

/// <summary>
/// Policy service factory.
/// </summary>
public class PolicyServiceFactory : IPolicyServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="serviceProvider">Service provider.</param>
    public PolicyServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Create service.
    /// </summary>
    /// <param name="type">Policy type.</param>
    /// <returns>Policy service.</returns>
    public IPolicyService CreateService(PolicyType type)
    {
        return type switch
        {
            PolicyType.Health => _serviceProvider.GetRequiredService<HealthsPolicyService>(),
            PolicyType.Life => _serviceProvider.GetRequiredService<LifeInsurancesService>(),
            PolicyType.Travel => _serviceProvider.GetRequiredService < TravelsPolicyService>(),
            _ => throw new NotImplementedException()
        };
    }
}
