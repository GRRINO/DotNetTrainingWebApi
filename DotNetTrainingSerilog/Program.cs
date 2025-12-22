using Serilog;

namespace DotNetTrainingSerilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setting up Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Set minimum log level
                .WriteTo.Console() // Write logs to console
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) // Optional: Write logs to file
                .CreateLogger();

            // Logging messages
            Log.Information("Hello, this is an info log!");
            Log.Warning("This is a warning message.");
            Log.Error("Oops! An error occurred!");
            Log.Debug("This is a debug message for developers.");
            Log.Fatal("This is a fatal error message.");
           

            // Ensure to flush and close logs before exit
            Log.CloseAndFlush();
        }
    }
}
