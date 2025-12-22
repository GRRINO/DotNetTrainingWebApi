using log4net;
using log4net.Config;

namespace DotNetTrainingLog4Net
{
    public class Program
    {
        // Set up the logger
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Configure log4net from config file
            XmlConfigurator.Configure();

            // Logging messages
            log.Info("This is an info log.");
            log.Warn("This is a warning log.");
            log.Error("This is an error log.");
            log.Debug("This is a debug log for developers.");
            log.Fatal("This is a fatal error log.");

            // Logs will be written to the "log.txt" file as per the rolling configuration
        }
    }
}
