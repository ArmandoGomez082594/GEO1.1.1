using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GEO1.1.1.Views
{
using Services;
using Xamarin.Forms.Maps;
[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GEOPage : ContentPage
	{
    #region Services
    GEOLocatorServices geolocatorServices;
    #endregion
    #region Constructors
    public GEOPage()
    {
        InitializeComponent();

        geolocatorServices = new GEOLocatorServices();
        MoveMapToCurrentPosition();
    }
    #endregion
    #region Methods
    async void MoveMapToCurrentPosition()
        {
        await geolocatorServices.GetLocation();
        if (geolocatorServices.Latitude != 0 ||
            geolocatorServices.Longitude != 0)
        {
            var position = new Position(
                geolocatorServices.Latitude,
                geolocatorServices.Longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromKilometers(.5)));
        }
        }

    #endregion
}
}