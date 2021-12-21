using System;
using CheckPointProject.Vehicle;

namespace CheckPointProject.Vehicle
{
    public abstract class AVehicle
    {
        public VehicleColor Color { get; protected set; }
        public VehicleBodyType BodyType { get; protected set; }
        public int LicensePlateNumber { get; protected set; }
        public bool HasPassenger { get; protected set; }
        protected Random random = new Random();

        public abstract int GetSpeed();
    }
}
