namespace AirVolunteer.Pages;

public partial class AddFlightPage : ContentPage
{
    public DateTime Tomorrow { get; set; }

    public AddFlightPage()
	{
		InitializeComponent();
        Tomorrow = DateTime.Today.AddDays(1); // Set tomorrow's date
    }

    private void HandleOriginConfirmation(object sender, EventArgs e)
    {
		_destinyEntry.Focus();
    }

    private void HandleDestinyConfirmation(object sender, EventArgs e)
    {
        _modelEntry.Focus();
    }

    private void HandleModelConfirmation(object sender, EventArgs e)
    {
        _paxEntry.Focus();
    }

    private void HandlePaxConfirmation(object sender, EventArgs e)
    {
        _loadEntry.Focus();
    }

    private async void OnContinueClicked(object sender, EventArgs e)
    {
        //check all is filled
        if (String.IsNullOrEmpty(_originEntry.Text)) {
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (String.IsNullOrEmpty(_destinyEntry.Text)) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (String.IsNullOrEmpty(_modelEntry.Text)) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (String.IsNullOrEmpty(_paxEntry.Text)) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (String.IsNullOrEmpty(_loadEntry.Text)) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (_departureDatePicker.Date != DateTime.MinValue) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (_arrivalDatePicker.Date != DateTime.MinValue) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (_departureTimePicker.Time != TimeSpan.Zero) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (_arrivalTimePicker.Time != TimeSpan.Zero) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }

        //create flight model


        //post api

        //return to previous page
    }

    private void HandleLoadConfirmation(object sender, EventArgs e)
    {
        _departureDatePicker.Focus();
    }
}