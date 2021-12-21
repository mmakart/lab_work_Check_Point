namespace CheckPointProject.Vehicle
{
    public class Truck : AVehicle
    {
        public override int GetSpeed()
        {
            return random.Next(70, 101);
        }

        public Truck(
            VehicleColor color,
            VehicleBodyType bodyType,
            int licenseNumber,
            bool hasPassenger)
        {
            Color = color;
            BodyType = bodyType;
            LicensePlateNumber = licenseNumber;
            HasPassenger = hasPassenger;
        }
    }
}
