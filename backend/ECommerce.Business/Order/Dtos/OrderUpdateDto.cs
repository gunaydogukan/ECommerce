namespace ECommerce.Business.Order.Dtos
{
    public record OrderUpdateDto
    {
        public string Status { get; set; } = null!;
    }
}
