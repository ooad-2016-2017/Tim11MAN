using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatTaxiAgencijaMAN.forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KontaktiranjeTaksija : Page
    {
        private Geoposition prva, druga;
        public KontaktiranjeTaksija()
        {
            this.InitializeComponent();
        }
        
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            var position = await locator.GetGeopositionAsync();
            await mapaPodaci.TrySetViewAsync(position.Coordinate.Point, 15D);
            prva = position;

            MapIcon mapIcon = new MapIcon();
            
            mapIcon.NormalizedAnchorPoint = new Point(0.25, 0.9);
            mapIcon.Location = position.Coordinate.Point;
            mapIcon.Title = "You are here";
            mapaPodaci.MapElements.Add(mapIcon);

            

        }

        private void mapaPodaci_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            var tappedGeoPosition = args.Location.Position;
            BasicGeoposition pocetna = new BasicGeoposition();
            pocetna.Latitude = prva.Coordinate.Latitude;
            pocetna.Longitude = prva.Coordinate.Longitude;
            ShowRouteOnMap(pocetna, tappedGeoPosition);

        }

        private async void ShowRouteOnMap(BasicGeoposition startLocation, BasicGeoposition endLocation)
        {
            
            // Get the route between the points.
            MapRouteFinderResult routeResult =
                  await MapRouteFinder.GetDrivingRouteAsync(
                  new Geopoint(startLocation),
                  new Geopoint(endLocation),
                  MapRouteOptimization.Time,
                  MapRouteRestrictions.None);

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Yellow;
                viewOfRoute.OutlineColor = Colors.Black;

                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                mapaPodaci.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await mapaPodaci.TrySetViewBoundsAsync(
                      routeResult.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
        }

    }
}
