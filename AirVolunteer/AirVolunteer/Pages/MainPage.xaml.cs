using AirVolunteer.APIs;
using AirVolunteer.Definitions;
using Shared.Models;

namespace AirVolunteer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void HandleCPFConfirmation(object sender, EventArgs e)
        {
            _nameEntry.Focus();
        }

        private void HandleNameConfirmation(object sender, EventArgs e)
        {
            _phoneEntry.Focus();
        }

        private void HandlePhoneConfirmation(object sender, EventArgs e)
        {
            OnContinueClicked(this, new EventArgs());
        }

        private async void OnContinueClicked(object sender, EventArgs e)
        {
            try {
                if (String.IsNullOrEmpty(_nameEntry.Text)
                    || String.IsNullOrEmpty(_phoneEntry.Text)
                    || String.IsNullOrEmpty(_cpfEntry.Text))
                {
                    await DisplayAlert("Oops", "Todos os campos são obrigatorios", "Ok");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_phoneEntry.CleanText)
                || _phoneEntry.CleanText.Length != 11)
                {
                    await DisplayAlert("Telefone inválido", "Você precisa informar o número do seu celular para confirmá-lo", "Ok");
                    return;
                }
                if (string.IsNullOrWhiteSpace(_cpfEntry.CleanText)
                    || _cpfEntry.CleanText.Length != 11)
                {
                    await DisplayAlert("CPF inválido", "Você precisa informar seu número de CPF", "Ok");
                    return;
                }
                if (string.IsNullOrWhiteSpace(_nameEntry.Text)
                    || _nameEntry.Text.Length <= 4)
                {
                    await DisplayAlert("Nome inválido", "Você precisa informar seu nome completo", "Ok");
                    return;
                }
                var pilot = new PilotMOD()
                {
                    CPF = long.Parse(_cpfEntry.CleanText),
                    Id = Guid.NewGuid(),
                    Name = _nameEntry.Text,
                    Phone = long.Parse(_phoneEntry.CleanText)
                };
                pilot = await PilotAPI.PostPilotAsync(pilot);
                Parameters.PilotID = pilot.Id.ToString();

                //Get all flights from this pilot
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _cpfEntry.Focus();
            var pilotID = Parameters.PilotID;
            if (!string.IsNullOrEmpty(pilotID))
            {
                //API to get Pilot
                var pilot = await PilotAPI.GetPilotAsync();

                //Go to next page
                var content = new ShellContent
                {
                    Title = "InPro APP",
                    ContentTemplate = new DataTemplate(() => new MainPage()),
                    Route = "MainPage"
                };
                var appShell = new AppShell();
                appShell.Items.Clear();
                appShell.Items.Add(content);
                ((App)Application.Current).ReplaceMainPage(appShell);
            }
        }
    }
}
