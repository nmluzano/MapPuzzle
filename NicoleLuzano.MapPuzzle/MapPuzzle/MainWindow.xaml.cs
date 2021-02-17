﻿using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NicoleLuzano.BingMapswithPushpin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Map.Center = new Microsoft.Maps.MapControl.WPF.Location(14.869418057402223, 120.47032030173744);
            Map.ZoomLevel = 13;

        }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            Point mousePosition = e.GetPosition(this);

            Location pinLocation = Map.ViewportPointToLocation(mousePosition);

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;
            pin.MouseDown += Map_PinOnclickEvent;
            Map.Children.Add(pin);
        }

        private void Map_PinOnclickEvent(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
            Pushpin pin = sender as Pushpin;
            MessageBox.Show("Lat:" + pin.Location.Latitude + " Long:" + pin.Location.Longitude);
        }
    }
}
