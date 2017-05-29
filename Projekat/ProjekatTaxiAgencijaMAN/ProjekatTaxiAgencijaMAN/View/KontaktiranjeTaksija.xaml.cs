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
using ProjekatTaxiAgencijaMAN.Modeli;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatTaxiAgencijaMAN.forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KontaktiranjeTaksija : Page
    {
        private bool nemoj = false;
        private int brojac = 0;
        private BasicGeoposition pocetna;
        MapRouteView viewOfRouteGlobal;
        MapIcon ikonica1;
        MapIcon ikonica2;
        Musterija m;
        public KontaktiranjeTaksija(Musterija m)
        {
            this.InitializeComponent();
            this.m = m;
        }

        private void mapaPodaci_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            brojac++;
            if (brojac > 2)
            {
                brojac = 0;
                nemoj = false;
                mapaPodaci.Routes.Remove(viewOfRouteGlobal);
                mapaPodaci.MapElements.Remove(ikonica1);
                mapaPodaci.MapElements.Remove(ikonica2);
            }
            var tappedGeoPosition = args.Location.Position;
            
            MapIcon ikonica = new MapIcon();
            ikonica.Location = args.Location;
            mapaPodaci.MapElements.Add(ikonica);
            if (brojac == 1)
            {
                ikonica1 = ikonica;
            }
            else if (brojac == 2)
            {
                ikonica2 = ikonica;
            }
            
            if (!nemoj)
            {
                pocetna = tappedGeoPosition;
                nemoj = true;
            }
            if (brojac == 2)
            {
                ShowRouteOnMap(pocetna, tappedGeoPosition);
            }

        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;
            var position = await locator.GetGeopositionAsync();
            await mapaPodaci.TrySetViewAsync(position.Coordinate.Point, 15D);            

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
                viewOfRouteGlobal = viewOfRoute;
                viewOfRoute.RouteColor = Colors.Blue;
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

        private void buttonZahtjevP_Click(object sender, RoutedEventArgs e)
        {
            //pristup bazi i dodat narudzbu u nju
        }
    }
}
