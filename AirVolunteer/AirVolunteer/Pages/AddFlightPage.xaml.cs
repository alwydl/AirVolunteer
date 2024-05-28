using AirVolunteer.APIs;
using AirVolunteer.Definitions;
using Shared.Models;
using System.ComponentModel;

namespace AirVolunteer.Pages;

public partial class AddFlightPage : ContentPage, INotifyPropertyChanged
{
    private DateTime _tomorrow;
    public DateTime Tomorrow 
    { 
        get
        {
            return _tomorrow;
        }
        set
        {
            if (value != _tomorrow)
            {
                _tomorrow = value;
                OnPropertyChanged();
            }
        } 
    }

    public AddFlightPage()
	{
		InitializeComponent();
        BindingContext = this;
        Tomorrow = DateTime.Today; // Set tomorrow's date
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
        if (_departureDatePicker.Date == DateTime.Today.Date) { 
                await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }
        if (_arrivalDatePicker.Date == DateTime.Today.Date) { 
            await DisplayAlert("Oops", "É necessário preencher todos os campos", "Ok");
            return;
        }

        //create flight model
        var flight = new FlightMOD()
        {
            AirplaneModel = _modelEntry.Text,
            Arrival = _arrivalDatePicker.Date.Add(_arrivalTimePicker.Time),
            PaxPositionsAvailable = int.Parse(_paxEntry.Text),
            DestinyAirport = _destinyEntry.Text,
            OriginAirport = _originEntry.Text,
            Departure = _departureDatePicker.Date.Add(_departureTimePicker.Time),
            FullPaxMaxLoad = int.Parse(_loadEntry.Text),
            PilotId = Guid.Parse(Parameters.PilotID),
            Id = Guid.Empty
        };

        
        //post api
        await FlightAPI.PostFlightAsync(flight);
        //return to previous page
        await Navigation.PopAsync();
    }

    private void HandleLoadConfirmation(object sender, EventArgs e)
    {
        _departureDatePicker.Focus();
    }
}