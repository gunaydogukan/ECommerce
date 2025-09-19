using ECommerce.Entities.Base;

namespace ECommerce.Entities.Identity
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //Navigation
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
