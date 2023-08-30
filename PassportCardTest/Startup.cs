using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PassportCard.Domain.Policies;
using PassportCard.Domain.Policies.HealthsPolicy;
using PassportCard.Domain.Policies.LifeInsurancesPolicy;
using PassportCard.Domain.Policies.TravelsPolicy;
using PassportCard.Domain.RatingEngines;

namespace PassportCardTest
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        private static IConfiguration _configuration;

        public static IServiceProvider CreateServiceProvider()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .Build();

            return host.Services;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("policy.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();


            services.Configure<LifeInsurancePolicy>(_configuration.GetSection("LifeInsurance"));

            services.Configure<TravelPolicy>(_configuration.GetSection("Travelpolicy")) ;
            services.Configure<HealthPolicy>(_configuration.GetSection("HealthPolicy"));

            services.Configure<GeneralPolicy>(x =>
            {
                var policyTypeVale = _configuration.GetValue<string>("GeneralPolicy:type");
                if (Enum.TryParse(policyTypeVale, out PolicyType policyType))
                {
                    x.Type = policyType;
                }
                var fullName= _configuration.GetValue<string>("GeneralPolicy:FullName");
                x.DateOfBirth = _configuration.GetValue<DateTime>("GeneralPolicy:DateOfBirth");
                x.FullName = fullName;
            });

            services.AddScoped<IRatingEngine, RatingEngine>();
            services.AddScoped<LifeInsurancesService>();
            services.AddSingleton<HealthsPolicyService>();
            services.AddSingleton<TravelsPolicyService>();

            services.AddSingleton<IPolicyServiceFactory, PolicyServiceFactory>();
        }
    }
}