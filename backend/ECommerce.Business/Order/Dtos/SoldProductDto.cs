namespace ECommerce.Business.Order.Dtos
{
    public record SoldProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }

        public List<SoldProductSaleDto> Sales { get; set; } = new();
    }

    public record SoldProductSaleDto
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerEmail { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}