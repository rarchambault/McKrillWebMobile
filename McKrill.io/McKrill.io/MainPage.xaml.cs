using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using McKrill.io.Backend;
using McKrill.io.Backend.Model;

namespace McKrill.io;

public partial class MainPage : ContentPage
{
    public float ExtWaterTemp { get; set; }
    public float IntTemp { get; set; }
    public int AirQualityIndex { get; set; }
    public float PowerLevels { get; set; }
    public ObservableCollection<Transit> TransitList { get; set; }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnTemperatureRefreshClick(object sender, EventArgs e)
    {

        var client = new McKrillApiClient();

        // Call various API endpoints
        var temperature = await client.GetTemperatureInformationAsync();

        ExtWaterTemp = temperature.TemperatureInformation.ExtWaterTemp;
        OnPropertyChanged(nameof(ExtWaterTemp));

        IntTemp = temperature.TemperatureInformation.IntTemp;
        OnPropertyChanged(nameof(IntTemp));
    }

    private async void OnAirRefreshClick(object sender, EventArgs e)
    {

        var client = new McKrillApiClient();

        // Call various API endpoints
        var airQuality = await client.GetAirQualityInformationAsync();

        AirQualityIndex = airQuality.AirQualityInformation.IntAirQuality;
        OnPropertyChanged(nameof(AirQualityIndex));
    }

    private async void OnPowerRefreshClick(object sender, EventArgs e)
    {

        var client = new McKrillApiClient();

        // Call various API endpoints
        var powerLevels = await client.GetPowerLevelInformationAsync();

        PowerLevels = powerLevels.PowerLevelInformation.PowerLevels;
        OnPropertyChanged(nameof(PowerLevels));
    }

    private async void OnTransitRefreshClick(object sender, EventArgs e)
    {

        var client = new McKrillApiClient();

        // Call various API endpoints
        var transitList = await client.GetTransitInformationAsync();

        TransitList = transitList.TransitList;
        OnPropertyChanged(nameof(TransitList));
    }
}


