using ECommerce.API.Controllers.Base;
using ECommerce.Business.Favorites.Commands.Add;
using ECommerce.Business.Favorites.Commands.Delete;
using ECommerce.Business.Favorites.Queries.GetMyFavorite;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;

namespace ECommerce.API.Controllers.Favorites
{
    public class FavoritesController : BaseController
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Ürünü favorilere ekler
        /// </summary>
        [HttpPost("add")]
        public async Task<IResult> AddFavorite([FromBody] AddFavroiteCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);
            return Success(data, "Ürün favorilere eklendi.", 201);
        }

        /// <summary>
        /// Favorilerden çıkar 
        /// </summary>
        [HttpDelete]
        public async Task<IResult> DeleteFavorites([FromBody] List<int> productIds, CancellationToken ct)
        {
            await _mediator.Send(new DeleteFavoriteCommand(productIds), ct);
            return Success("Favoriler başarıyla silindi.", 200);
        }

        /// <summary>
        /// Kullanıcının favorilerini getirir
        /// </summary>
        [HttpGet("my")]
        public async Task<IResult> GetMyFavorites(CancellationToken ct)
        {
            var favorites = await _mediator.Send(new GetMyFavoriteQuery(), ct);
            return Success(favorites, "Favoriler başarıyla getirildi.", 200);
        }
    }
}
