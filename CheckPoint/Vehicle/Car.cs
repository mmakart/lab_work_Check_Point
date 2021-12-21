namespace CheckPointProject.Vehicle
{
    public class Car : AVehicle
    {
        public override int GetSpeed()
        {
            return random.Next(90, 151);
        }
        public Car(
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
