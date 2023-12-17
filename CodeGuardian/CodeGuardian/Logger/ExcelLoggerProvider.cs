using CodeGuardian.API.Logger;
using Microsoft.Extensions.Options;

public class ExcelLoggerProvider : ILoggerProvider
{
    private readonly ExcelLogger _logger;

    public ExcelLoggerProvider(IOptions<ExcelLoggerConfiguration> options)
    {
        _logger = new ExcelLogger(options.Value);
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _logger;
    }

    public void Dispose()
    {
        // Libérez les ressources si nécessaire
    }
}
