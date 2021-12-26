using System;
using System.Collections.Generic;
using System.Text;
using CheckPointProject.Vehicle;

namespace CheckPointProject.CarRegister
{
    public class CheckPoint
    {
        public const int maxAllowedSpeed = 110;
        private long _vehiclesCount = 0;
        private double _vehicleSpeedsSum = 0;

        private CheckPointStatistics _statistics = new CheckPointStatistics();
        private List<string> _stolenNumbers = new List<string> {
            "10", "20", "30", "40", "50", "60", "70", "80", "90" };

        public CheckPointStatistics GetStatistics() => _statistics;

        public void RegisterCar(AVehicle vehicle)
        {
            // Always
            OnVehiclePass.Invoke(this, new VehicleEventArgs(vehicle));

            ++_vehiclesCount;

            var speed = vehicle.GetSpeed();
            _vehicleSpeedsSum += speed;

            _statistics.AverageSpeed = (int) (_vehicleSpeedsSum / _vehiclesCount);

            if (vehicle is Car)
            {
                _statistics.CarsCount++;
            }
            if (vehicle is Bus)
            {
                _statistics.BusesCount++;
            }
            if (vehicle is Truck)
            {
                _statistics.TrucksCount++;
            }

            if (speed > maxAllowedSpeed)
            {
                OnVehicleSpeeding.Invoke(this, new VehicleEventArgs(vehicle));
                _statistics.SpeedLimitBreakersCount++;
            }

            if (_stolenNumbers.Contains(vehicle.LicensePlateNumber.ToString()))
            {
                OnVehicleStolen.Invoke(this, new VehicleEventArgs(vehicle));
                _statistics.CarJackersCount++;
            }
        }

        public event EventHandler<VehicleEventArgs> OnVehiclePass;
        public event EventHandler<VehicleEventArgs> OnVehicleSpeeding;
        public event EventHandler<VehicleEventArgs> OnVehicleStolen;
    }
}
