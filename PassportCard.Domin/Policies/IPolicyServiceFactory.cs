namespace PassportCard.Domain.Policies;

/// <summary>
/// Policy service factory.
/// </summary>
public interface IPolicyServiceFactory
{
    /// <summary>
    /// Create service.
    /// </summary>
    /// <param name="type">Policy type.</param>
    /// <returns>Policy service.</returns>
    IPolicyService CreateService(PolicyType type);
}