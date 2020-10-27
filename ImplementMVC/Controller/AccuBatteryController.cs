using ImplementMVC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementMVC.Controller
{
    class AccuBatteryController
    {
        private AccuBattery accubattery;
        private OnPowerChanged callBackOnPowerChanged;

        public AccuBatteryController(OnPowerChanged callBackOnPowerChanged)
        {
            this.accubattery = new AccuBattery(12);
            this.callBackOnPowerChanged = callBackOnPowerChanged;
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }

        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callBackOnPowerChanged.OnPowerChangedStatus("ON", "Power is on");
        }

        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callBackOnPowerChanged.OnPowerChangedStatus("OFF", "Power is off");
        }
    }


    interface OnPowerChanged
    {
        void OnPowerChangedStatus(string value, string message);
    }
}
