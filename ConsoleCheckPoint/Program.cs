using System;
using CheckPointProject.CarRegister;
using CheckPointProject.Terminals;
using CheckPointProject.Vehicle;

namespace ConsoleCheckPoint
{
    public class Program
    {
        private static Random random = new Random();

        public static void Main(string[] args)
        {
            var checkPoint = new CheckPoint();

            using var randomTerminal = new TrafficFlowTerminalRandom(checkPoint);
            using var speedingTerminal = new TrafficFlowTerminalSpeeding(checkPoint);
            using var stolenTerminal = new TrafficFlowTerminalStolen(checkPoint);

            while (!Console.KeyAvailable)
            {
                System.Threading.Thread.Sleep(random.Next(500, 5001));
                var vehicle = VehicleFactory.GetRandomVehicle();
                checkPoint.RegisterCar(vehicle);
            }
        }
    }
}
