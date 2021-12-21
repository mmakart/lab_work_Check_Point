using System;
using System.Collections.Generic;
using System.Text;
using CheckPointProject.CarRegister;
using CheckPointProject.Vehicle;

namespace CheckPointProject.Terminals
{
    public class TrafficFlowTerminalRandom : IDisposable
    {
        private Random _random = new Random();
        private CheckPoint _checkPoint;

        public TrafficFlowTerminalRandom(CheckPoint checkPoint)
        {
            _checkPoint = checkPoint;
            _checkPoint.OnVehiclePass += PrintInfoAboutRandomVehicle;
        }

        private void PrintInfoAboutRandomVehicle(object sender, VehicleEventArgs vehicleEventArg)
        {
            var rand = _random.Next(0, 2);

            // Shorter name
            var vehicle = vehicleEventArg;

            if (rand == 1)
            {
                Console.WriteLine(string.Format(
                        "Random terminal registered a vehicle:\n" +
                        "Body type:      {0}\n" +
                        "Color:          {1}\n" +
                        "License number: {2}\n" +
                        "Has passenger:  {3}\n",
                        vehicle.bodyType,
                        vehicle.color,
                        vehicle.licensePlateNumber,
                        (vehicle.hasPassenger ? "yes" : "no")
                ));
            }
        }

        public void Dispose()
        {
            _checkPoint.OnVehiclePass -= PrintInfoAboutRandomVehicle;
        }
    }
}
