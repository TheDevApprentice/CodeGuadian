using ClosedXML.Excel;
using CodeGuardian.API.Logger;

public class ExcelLogger : ILogger, IExcelLogger
{
    private readonly string _filePath;
    private readonly object _lock = new object();

    public ExcelLogger(ExcelLoggerConfiguration configuration)
    {
        _filePath = configuration?.FilePath ?? "fichier.xlsx";
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        lock (_lock)
        {
            using (var workbook = LoadOrCreateWorkbook())
            {
                var worksheet = GetOrCreateWorksheet(workbook, "Logs");
                // Add code to write logs to the Excel worksheet
                // You can use worksheet.Cell(row, col).Value = "Log Message";
                workbook.SaveAs(_filePath);
            }
        }
    }

    public void LogApiConnection(string ipAddress, string method, string endpoint)
    {
        lock (_lock)
        {
            using (var workbook = LoadOrCreateWorkbook())
            {
                var worksheet = GetOrCreateWorksheet(workbook, "ApiConnections");
                // Add code to write connection information to the Excel worksheet
                // You can use worksheet.Cell(row, col).Value = "Log Message";
                worksheet.Cell(1, 1).Value = "IP Address";
                worksheet.Cell(1, 2).Value = "Method";
                worksheet.Cell(1, 3).Value = "Endpoint";
                worksheet.Cell(2, 1).Value = ipAddress;
                worksheet.Cell(2, 2).Value = method;
                worksheet.Cell(2, 3).Value = endpoint;
                workbook.SaveAs(_filePath);
            }
        }
    }

    public void LogMessage(string message)
    {
        lock (_lock)
        {
            using (var workbook = LoadOrCreateWorkbook())
            {
                var worksheet = GetOrCreateWorksheet(workbook, "Messages");
                LogLevel logLevel = LogLevel.Information;
                if (worksheet != null)
                {
                    // Ajoutez une nouvelle ligne avec la date, le message et l'identité du log
                    worksheet.Cell(worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1, 1).Value = DateTime.Now;
                    worksheet.Cell(worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1, 2).Value = message;
                    worksheet.Cell(worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1, 3).Value = logLevel.ToString();

                    workbook.SaveAs(_filePath);
                }
            }
        }
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    public IDisposable BeginScope<TState>(TState state) => null;

    private XLWorkbook LoadOrCreateWorkbook()
    {
        XLWorkbook workbook;
        try
        {
            // Check if the file exists before loading
            if (System.IO.File.Exists(_filePath))
            {
                workbook = new XLWorkbook(_filePath);
            }
            else
            {
                workbook = new XLWorkbook();
            }
        }
        catch
        {
            workbook = new XLWorkbook();
        }
        return workbook;
    }

    private IXLWorksheet GetOrCreateWorksheet(XLWorkbook workbook, string worksheetName)
    {
        var worksheet = workbook.Worksheets.FirstOrDefault(w => w.Name == worksheetName);
        if (worksheet == null)
        {
            // Worksheet does not exist, create a new one
            worksheet = workbook.AddWorksheet(worksheetName);
        }
        return worksheet;
    }
}
