namespace PassportCard.Domain.Policies;

/// <summary>
/// General policy.
/// </summary>
public class GeneralPolicy 
{
    /// <summary>
    /// Type.
    /// </summary>
    public PolicyType Type { get; set; }
    
    /// <summary>
    /// Full name.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Date of birth.
    /// </summary>
    public DateTime DateOfBirth { get; set; }
}