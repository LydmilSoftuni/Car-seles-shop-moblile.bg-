namespace Racism.Models
{
    public class UserCar
    {
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}