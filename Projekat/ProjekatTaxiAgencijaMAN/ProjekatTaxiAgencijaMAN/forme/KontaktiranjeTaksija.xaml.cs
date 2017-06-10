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

        double cijenaRacunanje (double duzina)
        {
            if (duzina < 1000) return 1;
            return duzina / 1000;
        }

        public KontaktiranjeTaksija(Musterija m)
        {
            this.InitializeComponent();
            this.m = m;
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        public KontaktiranjeTaksija()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        public double GetDistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
        {
            double distance = 0;

            double dLat = (lat2 - lat1) / 180 * Math.PI;
            double dLong = (long2 - long1) / 180 * Math.PI;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                        + Math.Cos(lat1 / 180 * Math.PI) * Math.Cos(lat2 / 180 * Math.PI)
                        * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            //Calculate radius of earth
            // For this you can assume any of the two points.
            double radiusE = 6378135; // Equatorial radius, in metres
            double radiusP = 6356750; // Polar Radius

            //Numerator part of function
            double nr = Math.Pow(radiusE * radiusP * Math.Cos(lat1 / 180 * Math.PI), 2);
            //Denominator part of the function
            double dr = Math.Pow(radiusE * Math.Cos(lat1 / 180 * Math.PI), 2)
                            + Math.Pow(radiusP * Math.Sin(lat1 / 180 * Math.PI), 2);
            double radius = Math.Sqrt(nr / dr);

            //Calculate distance in meters.
            distance = radius * c;
            return distance; // distance in meters
        }

        private void mapaPodaci_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            brojac++;
            if (brojac > 2)
            {
                brojac = 1;
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
                pocetna = tappedGeoPosition;
                ikonica1 = ikonica;
            }
            else if (brojac == 2)
            {
                ikonica2 = ikonica;
                ShowRouteOnMap(pocetna, tappedGeoPosition);
                double privremeni = Math.Round(GetDistanceBetweenPoints(pocetna.Latitude, pocetna.Longitude, tappedGeoPosition.Latitude, tappedGeoPosition.Longitude), 2);
                textBlockDuzinaRute.Text = privremeni.ToString()+" m";
                textBlockCijenaP.Text = "Cijena: " + Math.Round(cijenaRacunanje(privremeni),2) + " KM";
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
