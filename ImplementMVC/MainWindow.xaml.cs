using ImplementMVC.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImplementMVC
{
    
    public partial class MainWindow : Window, OnDoorChanged, OnPowerChanged , OnCarEngineStatusChanged
    {
        private Car nextCar;
        public MainWindow()
        {
            InitializeComponent();
            AccuBatteryController accuBatteryController = new AccuBatteryController(this);
            DoorController doorController = new DoorController(this);
            nextCar = new Car(accuBatteryController, doorController, this);
        }

        public void carEngineStatusChanged(string value, string message)
        {
            status.Content = message;
            startButton.Content = value;
        }
        public void doorSecurityChanged(string vale, string message)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = vale;
        }

        public void doorStatusChanged(string vale, string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButten.Content = vale;
        }

        public void OnPowerChangedStatus(string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleThePowerButton();
        }

        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheDoorButton();
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLockedDoorButton();
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleStartEngineButton();
        }
    }
}
