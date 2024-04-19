using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Categories.Commands;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using PracticeShoppingApp.Application.Features.Categories.Queries;
using PracticeShoppingApp.Application.Validation;

namespace PracticeShoppingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<GetCategoryDetailsDto>> GetCategorybyId(Guid id)
        {
            var getCategoryByIdRequest = new GetCategoryByIdRequest();
            var Category = await _mediator.Send(getCategoryByIdRequest);
            if (Category == null)
                return NotFound();
            return Ok(Category);
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetCategoryListDto>>> GetAllCategories()
        {
            var getCategoriesListRequest = new GetCategoriesListRequest();
            var categoryList = await _mediator.Send(getCategoriesListRequest);
            if (categoryList == null)
                return NotFound();
            return Ok(categoryList);
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("allwithproducts", Name = "GetCategoriesWithProducts")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetCategoryProductListDto>>> GetCategoriesWithProducts()
        {
            var getCategoriesWithProductsRequest = new GetCategoriesListWithProductsRequest();
            var GetCategoriesListWithProductsResponse = await _mediator.Send(getCategoriesWithProductsRequest);
            if (GetCategoriesListWithProductsResponse == null)
                return NotFound();
            return Ok(GetCategoriesListWithProductsResponse);
        }

        [Authorize(Roles = "admin")]
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            var validator = new CreateCategoryValidator();
            var validationResult = await validator.ValidateAsync(createCategoryRequest);
            if (validationResult.Errors.Count > 0)
            {
                return BadRequest(validationResult.Errors);
            }
            var newCategory = _mediator.Send(createCategoryRequest);
            return Ok(newCategory);
        }
    }
}
