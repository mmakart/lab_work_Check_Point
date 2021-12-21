using System;
using CheckPointProject.CarRegister;
using CheckPointProject.Vehicle;

namespace CheckPointProject.Terminals
{
    public class TrafficFlowTerminalStolen : IDisposable
    {
        private CheckPoint _checkPoint;

        public TrafficFlowTerminalStolen(CheckPoint checkPoint)
        {
            _checkPoint = checkPoint;
            _checkPoint.OnVehicleStolen += PrintStolenVehicleInfo;
        }

        public void PrintStolenVehicleInfo(object sender, VehicleEventArgs vehicleEventArgs)
        {
            var vehicle = vehicleEventArgs;

            Console.WriteLine(string.Format(
                    "Terminal of stolen vehicles registered a stolen car:\n" +
                    "License number: {0}\n" +
                    "Body type:      {1}\n" +
                    "Color:          {2}\n",
                    vehicle.licensePlateNumber,
                    vehicle.bodyType,
                    vehicle.color
            ));
        }

        public void Dispose()
        {
            _checkPoint.OnVehicleStolen -= PrintStolenVehicleInfo;
        }
    }
}
