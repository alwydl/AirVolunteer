namespace AirVolunteer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public void ReplaceMainPage(Page newPage)
        {
            MainPage = newPage;
        }
    }
}
