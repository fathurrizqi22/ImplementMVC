using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementMVC.Controller
{
    class Car
    {
        AccuBatteryController accuBatteryController;
        DoorController doorController;
        OnCarEngineStatusChanged callbackCarEngineStatusChanged;

        public Car(AccuBatteryController accuBatteryController,
                   DoorController doorController,
                   OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accuBatteryController = accuBatteryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public void turnOnPower()
        {
            this.accuBatteryController.turnOn();
        }

        public void turnOffPower()
        {
            this.accuBatteryController.turnOff();
        }

        public bool powerIsReady()
        {
            return this.accuBatteryController.accubatteryIsOn();
        }

        public void closeTheDoor()
        {
            this.doorController.close();
        }

        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }

        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }

        public bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        public bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        public void toggleStartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "Door is opened");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "Door is Unlock");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "No power available");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine started");
        }

        public void toggleTheLockedDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }

        public void toggleTheDoorButton()
        {
            if (!doorIsLocked())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }

        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOffPower();
            }
        }
    }


    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
}
