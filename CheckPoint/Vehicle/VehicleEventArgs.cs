using System;

namespace CheckPointProject.Vehicle
{
    public class VehicleEventArgs : EventArgs
    {
        public VehicleColor color;
        public VehicleBodyType bodyType;
        public int licensePlateNumber;
        public bool hasPassenger;

        public VehicleEventArgs(AVehicle vehicle)
        {
            color = vehicle.Color;
            bodyType = vehicle.BodyType;
            licensePlateNumber = vehicle.LicensePlateNumber;
            hasPassenger = vehicle.HasPassenger;
        }
    }
}
