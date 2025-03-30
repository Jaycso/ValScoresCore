namespace ValScoresCore
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
            Application.Run(new splashScreen());
        }

        public static class Helper
        {
            public static void goToNext(Form currentForm, Form nextForm) // opens next page
            {
                nextForm.Closed += (s, args) => currentForm.Close();
                nextForm.Show();
                currentForm.Hide();
            }
        }
    }
}