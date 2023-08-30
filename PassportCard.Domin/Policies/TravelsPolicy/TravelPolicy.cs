namespace PassportCard.Domain.Policies.TravelsPolicy;

/// <summary>
/// Travel policy
/// </summary>
public class TravelPolicy
{
    /// <summary>
    /// Country.
    /// </summary>
    public string Country { get; set; }
    
    /// <summary>
    /// Days.
    /// </summary>
    public int Days { get; set; }
}