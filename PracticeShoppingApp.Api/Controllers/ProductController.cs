using AutoMapper;
using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Events.Commands.CreateEvent;
using PracticeShoppingApp.Application.Features.Products;
using PracticeShoppingApp.Application.Features.Products.Commands;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.Application.Features.Products.Queries;
using PracticeShoppingApp.Application.Validation;
using PracticeShoppingApp.Domain.Entities;

namespace PracticeShoppingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public ProductController(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }
        [Authorize(Roles = "admin,user")]
        [HttpGet("All",Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetProductListDto>>> GetAllProducts()
        {
            var getProductListRequest = new GetProductListRequest();
            var AllProducts = await _mediator.Send(getProductListRequest);
            if (AllProducts == null)
                return NotFound();
            return Ok(AllProducts);
        }
        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<GetProductDetailDto>> GetProductbyId(Guid id)
        {
            var getProductDetailQuery = new GetProductDetailsRequest() { Id = id };
            var productDetailResponse = await _mediator.Send(getProductDetailQuery);
            if (productDetailResponse == null) 
                return NotFound();
            else 
                return Ok(productDetailResponse);

        }
        [Authorize(Roles = "admin")]
        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductRequest createProductDto)
        {
            var validator = new CreateProductValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(createProductDto);
            if (validationResult.Errors.Count > 0)
                return BadRequest(validationResult.Errors);
            var newProduct = await _mediator.Send(createProductDto);
            return Ok(newProduct);
        }
        [Authorize(Roles = "admin")]
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductRequest updateProductDto)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(updateProductDto.ProdId);
            if (productToUpdate == null) 
                return NotFound();
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(updateProductDto);
            if (validationResult.Errors.Count > 0) 
                return BadRequest(validationResult.Errors);
            await _mediator.Send(updateProductDto);
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProdRequest = new DeleteProductRequest() { ProdId = id };
            await _mediator.Send(deleteProdRequest);
            return Ok();
        }
    }
}
