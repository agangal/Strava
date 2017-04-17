using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StravaUWP.CustomControl
{
    using StravaDotNet;
    using Windows.Devices.Geolocation;
    using Windows.UI;
    using Windows.UI.Xaml.Controls.Maps;

    public sealed partial class FeedMapControl : UserControl
    {
        public FeedMapControl()
        {
            this.InitializeComponent();
        }

        public string EncodedPolyline
        {
            get { return (string)GetValue(EncodedPolylineProperty); }
            set
            {
                SetValue(EncodedPolylineProperty, value);
                UpdateMap(value.ToString());
            }
        }
        public static readonly DependencyProperty EncodedPolylineProperty = DependencyProperty.Register("EncodedPolyline", typeof(string), typeof(FeedMapControl), null);
        
        public double StartLatitude
        {
            get { return (double)GetValue(StartLatitudeProperty); }
            set
            {
                SetValue(StartLatitudeProperty, value);
                CenterMap();
            }
        }
        public static readonly DependencyProperty StartLatitudeProperty = DependencyProperty.Register("StartLatitude", typeof(double), typeof(FeedMapControl), null);
        public double StartLongitude
        {
            get { return (double)GetValue(StartLongitudeProperty); }
            set
            {
                SetValue(StartLongitudeProperty, value);
                CenterMap();
            }
        }
        public static readonly DependencyProperty StartLongitudeProperty = DependencyProperty.Register("StartLongitude", typeof(double), typeof(FeedMapControl), null);
        public double EndLatitude
        {
            get { return (double)GetValue(EndLatitudeProperty); }
            set
            {
                SetValue(EndLatitudeProperty, value);
                CenterMap();
            }
        }
        public static readonly DependencyProperty EndLatitudeProperty = DependencyProperty.Register("EndLatitude", typeof(double), typeof(FeedMapControl), null);
        public double EndLongitude
        {
            get { return (double)GetValue(EndLongitudeProperty); }
            set
            {
                SetValue(EndLongitudeProperty, value);
                CenterMap();
            }
        }
        public static readonly DependencyProperty EndLongitudeProperty = DependencyProperty.Register("EndLongitude", typeof(double), typeof(FeedMapControl), null);
        private void UpdateMap(string polyline)
        {           
            if (!String.IsNullOrEmpty(polyline))
            {
                List<BasicGeoposition> Coordinates = PolylineDecoder.Decode(polyline);
                MapPolyline MapPolyline = new MapPolyline();
                MapPolyline.StrokeColor = Colors.OrangeRed;
                MapPolyline.StrokeThickness = 2;
                MapPolyline.Path = new Geopath(Coordinates);
                this.FeedMapView.MapElements.Add(MapPolyline);
                FeedMapView.Center = new Geopoint(Coordinates[0]);
            }
        }

        private void CenterMap()
        {
            try
            {
                FeedMapView.Center = new Geopoint(new BasicGeoposition
                {
                    Latitude = StartLatitude,
                    Longitude = StartLatitude
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error setting Map Center : {0}", ex.Message);
            }
        }
    }
}
