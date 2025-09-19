using ECommerce.Entities.Base;

namespace ECommerce.Entities.Identity
{
    public class Permission : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
