using ECommerce.API.Controllers.Base;
using ECommerce.Business.Order.Commands.Add;
using ECommerce.Business.Order.Queries.GetMy;
using ECommerce.Business.Order.Queries.GetSoldProducts;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;

namespace ECommerce.API.Controllers.Orders
{
    public class OrdersController : BaseController
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Yeni sipariş oluşturur (direkt item listesi veya sepet üzerinden).
        /// </summary>
        [HttpPost]
        public async Task<IResult> Add([FromBody] AddOrderCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);

            return Success(data, "Sipariş başarıyla oluşturuldu.", 201);
        }

        [HttpGet("my")]
        public async Task<IResult> GetMyOrders(CancellationToken ct)
        {
            var orders = await _mediator.Send(new GetMyOrdersQuery(), ct);

            return Success(orders, "Siparişler başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Satıcının sattığı ürünleri listeler.
        /// </summary>
        [HttpGet("sold-products")]
        public async Task<IResult> GetMySoldProducts(CancellationToken ct)
        {
            var products = await _mediator.Send(new GetSoldProductsBySellerQuery(), ct);

            return Success(products, "Satılan ürünler başarıyla getirildi.", 200);
        }
    }
}