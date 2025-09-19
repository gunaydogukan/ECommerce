namespace ECommerce.Business.Order.Dtos
{
    public class SoldProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal TotalRevenue { get; set; }

        // Alıcı bilgileri
        public int BuyerId { get; set; }
        public string BuyerEmail { get; set; } = null!;
    }
}