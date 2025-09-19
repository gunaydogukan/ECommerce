using ECommerce.Entities.Base;

namespace ECommerce.Entities.Identity
{
    public class Role : AuditableEntity
    {
        public string Name { get; set; } = null!;
    }
}
