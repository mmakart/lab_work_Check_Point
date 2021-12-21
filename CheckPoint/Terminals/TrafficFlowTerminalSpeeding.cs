using System;
using CheckPointProject.CarRegister;
using CheckPointProject.Vehicle;

namespace CheckPointProject.Terminals
{
    public class TrafficFlowTerminalSpeeding : IDisposable
    {
        private CheckPoint _checkPoint;

        public TrafficFlowTerminalSpeeding(CheckPoint checkPoint)
        {
            _checkPoint = checkPoint;
            _checkPoint.OnVehicleSpeeding += PrintSpeedViolatorInfo;
        }

        public void PrintSpeedViolatorInfo(object sender, VehicleEventArgs vehicleEventArg)
        {
            var vehicle = vehicleEventArg;

            Console.WriteLine(string.Format(
                    "Speeding terminal registered a vehicle:\n" +
                    "License number: {0}\n",
                    vehicle.licensePlateNumber
            ));
        }

        public void Dispose()
        {
            _checkPoint.OnVehicleSpeeding -= PrintSpeedViolatorInfo;
        }
    }
}
