namespace PassportCard.Domain.Policies.LifeInsurancesPolicy;

/// <summary>
/// Life insurance policy
/// </summary>
public class LifeInsurancePolicy 
{
    /// <summary>
    /// Is smoker.
    /// </summary>
    public bool IsSmoker { get; set; }
    
    /// <summary>
    /// Amount.
    /// </summary>
    public decimal Amount { get; set; }
}