
namespace GEO1.1.1.Services
{
    using System.Threading.Tasks;
    using Plugin.Geolocator;
    using System;
    public class GEOLocatorServices
        {
    #region Properties
    public double Latitude
    {
        get;
        set;
    }
    public Double Longitude
    {
        get;
        set;
    }
    #endregion

    #region Methods
        public async Task GetLocation()
            {
                try
                    {
                        var locator = CrossGeolocator.Current;
                        locator.DesiredAccuracy = 50;
                        var location = await locator.GetPositionAsync();
                        Latitude = location.Latitude;
                        Longitude = location.Longitude;
                     }
                catch(Exception ex)
                    {
                        ex.ToString();
                    }
            }
    #endregion
    }
}
