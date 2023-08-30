namespace PassportCard.Domain.RatingEngines;

/// <summary>
/// Rating engine.
/// </summary>
public interface IRatingEngine
{
    /// <summary>
    /// Get rate data.
    /// </summary>
    /// <returns>Decimal.</returns>
    decimal GetRateData();
}