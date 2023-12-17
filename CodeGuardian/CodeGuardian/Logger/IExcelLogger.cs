public interface IExcelLogger
{
    void LogApiConnection(string ipAddress, string method, string endpoint);
    void LogMessage(string message); 
}