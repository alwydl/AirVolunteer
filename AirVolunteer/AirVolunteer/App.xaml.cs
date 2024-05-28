namespace AirVolunteer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            MainPage = new AppShell();
        }

        public void ReplaceMainPage(Page newPage)
        {
            MainPage = newPage;
        }

        private async void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            throw ex;
        }
    }
}
