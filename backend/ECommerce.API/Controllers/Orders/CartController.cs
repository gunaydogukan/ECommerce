using ECommerce.API.Controllers.Base;
using ECommerce.Business.Cart.Commands.Add;
using ECommerce.Business.Cart.Commands.Update;
using ECommerce.Business.Cart.Commands.Delete;
using ECommerce.Business.Cart.Queries.GetMyCart;
using ECommerce.Core.Helpers.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;

namespace ECommerce.API.Controllers.Orders
{
    public class CartController : BaseController
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Giriş yapmış kullanıcının sepetini getirir
        /// </summary>
        [HttpGet("me")]
        public async Task<IResult> GetMyCart(CancellationToken ct)
        {
            var carts = await _mediator.Send(new GetMyCartQuery(), ct);
            return Success(carts, "Sepet başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Sepete ürün ekler
        /// </summary>
        [HttpPost]
        public async Task<IResult> Add([FromBody] AddToCartCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);
            return Success(data, "Ürün sepete eklendi.", 201);
        }

        /// <summary>
        /// Sepet öğesinin miktarını günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IResult> Update([FromBody] UpdateCartCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);

            return Success(data, "Sepet öğesi başarıyla güncellendi.", 200);
        }

        /// <summary>
        /// Sepet öğesini siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IResult> Remove(int id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteFromCartCommand(id), ct);
            return Success("Sepet öğesi başarıyla silindi.", 200);
        }
    }
}
