namespace CheckPointProject.Vehicle
{
    public class Bus : AVehicle
    {
        public override int GetSpeed()
        {
            return random.Next(80, 111);
        }

        public Bus(
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
