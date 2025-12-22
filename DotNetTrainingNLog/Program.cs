using NLog;

namespace DotNetTrainingNLog
{
    public class Program
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Logger.Info("This is an info log!");
            Logger.Warn("This is a warning log.");
            Logger.Error("An error occurred!");
            Logger.Debug("This is a debug log for developers.");
            Logger.Fatal("This is a fatal error log.");

            LogManager.Shutdown();
            Console.ReadKey(); // console မပိတ်သွားအောင်
        }
    }
}
