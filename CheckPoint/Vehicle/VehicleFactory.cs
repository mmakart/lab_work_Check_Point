using System;

namespace CheckPointProject.Vehicle
{
    public static class VehicleFactory
    {
        private static Random _random = new Random();
        // NOTE! Must be modified when adding or removing AVehicle descendants
        private const int _vehicleClassCount = 3;

        public static AVehicle GetRandomVehicle()
        {
            var vehicleClassNumber = _random.Next(_vehicleClassCount);

            var totalColors = Enum.GetNames(typeof(VehicleColor)).Length;
            var totalBodyTypes = Enum.GetNames(typeof(VehicleBodyType)).Length;

            var color = (VehicleColor) _random.Next(totalColors);
            var bodyType = (VehicleBodyType) _random.Next(totalBodyTypes);
            var licenseNumber = _random.Next(100);
            var hasPassenger = (_random.Next(2) == 1 ? true : false);

            switch (vehicleClassNumber)
            {
                case 0:
                    return new Car(color, bodyType, licenseNumber, hasPassenger);
                case 1:
                    return new Truck(color, bodyType, licenseNumber, hasPassenger);
                case 2:
                    return new Bus(color, bodyType, licenseNumber, hasPassenger);
                default:
                    throw new Exception("Exception in VehicleFactory.GetRandomVehicle: " +
                            "no such AVehicle descendant");
            }
        }
    }
}
