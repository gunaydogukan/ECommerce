﻿namespace ECommerce.Business.OrderItem.Dtos
{
    public class OrderItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public decimal UnitPrice { get; set; }
    }
}
