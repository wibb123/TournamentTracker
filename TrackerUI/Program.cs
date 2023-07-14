using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Initialise the database connections
            TrackerLibrary.GlobalConfig.InitialiseConnections(DatabaseType.Textfile);

            Application.Run(new TournamentDashboardForm());
            
            // Application.Run(new TournamentDashboardForm());
        }
    }
}