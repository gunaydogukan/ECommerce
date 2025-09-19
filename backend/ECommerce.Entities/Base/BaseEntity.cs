using ECommerce.Entities.Base.Abstracts;

namespace ECommerce.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
