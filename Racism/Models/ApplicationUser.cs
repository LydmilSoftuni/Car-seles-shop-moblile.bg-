using Microsoft.AspNetCore.Identity;

namespace Racism.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsBuyer { get; set; } = false;
        public bool IsSeller { get; set; } = false;


        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
    }
}