namespace PassportCard.Domain.Policies.HealthsPolicy;

/// <summary>
/// Health policy.
/// </summary>
public class HealthPolicy 
{
    /// <summary>
    /// Gender.
    /// </summary>
    public string Gender { get; set; }

    /// <summary>
    /// Deductible.
    /// </summary>
    public decimal Deductible { get; set; }
}