namespace PassportCard.Domain.Policies;

/// <summary>
/// Policy service.
/// </summary>
public interface IPolicyService
{
    /// <summary>
    /// Get Rate.
    /// </summary>
    /// <returns>Decimal.</returns>
    decimal GetRate();
}
