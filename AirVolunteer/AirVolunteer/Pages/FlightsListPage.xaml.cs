using AirVolunteer.APIs;
using Shared.Models;
using System.ComponentModel;

namespace AirVolunteer.Pages;

public partial class FlightsListPage : ContentPage, INotifyPropertyChanged
{
    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (_isLoading != value)
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
    }
    private List<FlightMOD> _flights;
    public List<FlightMOD> Flights
    {
        get { return _flights; }
        set
        {
            if (_flights != value)
            {
                _flights = value;
                OnPropertyChanged();
            }
        }
    }
    public FlightsListPage(List<FlightMOD> flights)
	{
		InitializeComponent();
        BindingContext = this; // Set this page as BindingContext
        _refreshView.Command = new Command(
            async () => await FetchModels()
            );
        Flights = flights.OrderBy(x => x.Departure).ToList();
    }

    private async Task FetchModels()
    {
        try
        {
            IsLoading = true;
            Flights = await FlightAPI.GetFlightsAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async void OnAddFlightClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddFlightPage());
    }
}