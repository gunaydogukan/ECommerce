using ECommerce.Business.Products.Commands.Add;
using ECommerce.Business.Products.Commands.Update;
using ECommerce.Business.Products.Commands.Delete;
using ECommerce.Business.Products.Queries.GetAllProducts;
using ECommerce.Business.Products.Queries.GetProductById;
using ECommerce.Business.Products.Queries.GetProductsByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Controllers.Base;
using ECommerce.Business.Products.Queries.GetProductsByCategory;
using IResult = ECommerce.Core.Responses.Abstracts.IResult;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.API.Controllers.Catalog
{
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator )
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Tüm ürünleri getirir
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IResult> GetAll(CancellationToken ct)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(), ct);
            return Success(products, "Ürünler başarıyla getirildi.", 200);
        }

        [HttpGet("by-category/{categoryId}")]
        [AllowAnonymous]
        public async Task<IResult> GetByCategory(int categoryId, CancellationToken ct)
        {
            var products = await _mediator.Send(new GetProductsByCategoryQuery(categoryId), ct);
            return Success(products, "Kategoriye göre ürünler başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Id’ye göre ürün getirir 
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IResult> GetById(int id, CancellationToken ct)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id), ct);
            return Success(product, "Ürün başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Kullanıcının kendi ürünlerini getirir
        /// </summary>
        [HttpGet("my")]
        public async Task<IResult> GetMyProducts(CancellationToken ct)
        {
            var products = await _mediator.Send(new GetMyProductsQuery(), ct);

            return Success(products, "Kullanıcı ürünleri başarıyla getirildi.", 200);
        }

        /// <summary>
        /// Yeni ürün ekler
        /// </summary>
        [HttpPost]
        public async Task<IResult> Add([FromBody] AddProductCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);

            return Success(data, "Ürün başarıyla eklendi.", 201);
        }

        /// <summary>
        /// Ürün günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IResult> Update(int id, [FromBody] UpdateProductCommand command, CancellationToken ct)
        {
            var data = await _mediator.Send(command, ct);
            return Success(data, "Ürün başarıyla güncellendi.", 200);
        }

        /// <summary>
        /// Ürün siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id, CancellationToken ct)
        {
            await _mediator.Send(new DeleteProductCommand(id), ct);
            return Success("Ürün başarıyla silindi.", 200);
        }
    }
}
