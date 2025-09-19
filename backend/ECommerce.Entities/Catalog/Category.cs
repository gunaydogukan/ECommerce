using ECommerce.Entities.Base;

namespace ECommerce.Entities.Catalog
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; } = null!;

        //Navigaiton 
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
