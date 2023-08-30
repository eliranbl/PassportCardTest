using Microsoft.Extensions.DependencyInjection;
using PassportCard.Domain.RatingEngines;
using PassportCardTest;

/// <summary>
/// Program.
/// </summary>
public class Program
{
    private static IServiceProvider _serviceProvider;

    /// <summary>
    /// Main.
    /// </summary>
    static void Main()
    {
        _serviceProvider = Startup.CreateServiceProvider();

        var rate = _serviceProvider.GetRequiredService<IRatingEngine>().GetRateData();

        Console.WriteLine(rate);
    }
}