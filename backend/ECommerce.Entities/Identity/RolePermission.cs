using ECommerce.Entities.Base;

namespace ECommerce.Entities.Identity
{
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        //Navigation
        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
