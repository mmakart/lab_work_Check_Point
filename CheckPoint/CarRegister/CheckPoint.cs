using System;
using System.Collections.Generic;
using System.Text;
using CheckPointProject.Vehicle;

namespace CheckPointProject.CarRegister
{
    public class CheckPoint
    {
        public const int maxPossibleSpeed = 110;
        private long vehiclesCount = 0;
        private double vehicleSpeedsSum = 0;

        private CheckPointStatistics _statistics = new CheckPointStatistics();
        private List<string> _stolenNumbers = new List<string> {
            "10", "20", "30", "40", "50", "60", "70", "80", "90" };

        public CheckPointStatistics GetStatistics() => _statistics;
        
        public void RegisterCar(AVehicle vehicle)
        {
            // Always
            OnVehiclePass.Invoke(this, new VehicleEventArgs(vehicle));
            
            ++vehiclesCount;

			var speed = vehicle.GetSpeed();
            vehicleSpeedsSum += speed;

            _statistics.AverageSpeed = (int) (vehicleSpeedsSum / vehiclesCount);

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

            if (speed > maxPossibleSpeed)
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
