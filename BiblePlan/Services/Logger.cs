using BiblePlan.Domain;

namespace BiblePlan.Services
{
    public static class Logger
    {
        public static void LogThis<T>(this T sender, string message, Result result)
        {
            string logFilePath = "./log.txt";
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {sender} - {result} - {message}";

            try
            {
                if (!File.Exists(logFilePath))
                {
                    using (StreamWriter writer = File.CreateText(logFilePath))
                    {
                        writer.WriteLine(logEntry);
                    }
                }
                else
                {
                    using (StreamWriter writer = File.AppendText(logFilePath))
                    {
                        writer.WriteLine(logEntry);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging: {ex.Message}");
            }
        }
    }
    public enum Result
    {
        Success,
        Failure,
        Unknown
    }
}
