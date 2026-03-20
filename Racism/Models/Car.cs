namespace Racism.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearOfManufacturing { get; set; }
        public int RangeKm { get; set; }
        public bool Sold { get; set; } = false;

        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
    }
}