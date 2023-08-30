
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PassportCard.Domain.Policies.LifeInsurancesPolicy;

public class LifeInsurancesService : IPolicyService
{
    private readonly LifeInsurancePolicy _healthPolicy;
    private readonly  GeneralPolicy _generalPolicy;
    private readonly ILogger<LifeInsurancesService> _logger;
    
    public LifeInsurancesService(IOptions<LifeInsurancePolicy> healthPolicy,
        ILogger<LifeInsurancesService> logger,
        IOptions<GeneralPolicy> generalPolicy)
    {
        _healthPolicy = healthPolicy.Value;
        _logger = logger;
        _generalPolicy = generalPolicy.Value;
    }

    public decimal GetRate()
    {
        decimal rating = 0;
        _logger.LogInformation("Rating LIFE policy...");
        _logger.LogInformation("Validating policy.");
        if (_generalPolicy.DateOfBirth == DateTime.MinValue)
        {
            _logger.LogError("Life policy must include Date of Birth.");
            return rating;
        }
        if (_generalPolicy.DateOfBirth < DateTime.Today.AddYears(-100))
        {
            _logger.LogError("Max eligible age for coverage is 100 years.");
            return rating;
        }
        if (_healthPolicy.Amount == 0)
        {
            _logger.LogError("Life policy must include an Amount.");
            return rating;
        }

        var age = DateTime.Today.Year - _generalPolicy.DateOfBirth.Year;

        if (_generalPolicy.DateOfBirth.Month == DateTime.Today.Month &&
            DateTime.Today.Day < _generalPolicy.DateOfBirth.Day ||
            DateTime.Today.Month < _generalPolicy.DateOfBirth.Month)
        {
            age--;
        }
        var baseRate = _healthPolicy.Amount * age / 200;

        if (_healthPolicy.IsSmoker)
        {
            rating = baseRate * 2;
            return rating;
        }
        rating = baseRate;

        return rating;
    }


}