using AutoMapper;
using MediatR;
using PracticeShoppingApp.Application.Contracts.Presistence;
using PracticeShoppingApp.Application.Features.Products.Dtos;
using PracticeShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PracticeShoppingApp.Application.Features.Products.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<GetProductListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _asyncProductRepository;
        public GetProductListRequestHandler(IProductRepository asyncProductRepository, IMapper mapper)
        {
            _mapper = mapper;
            _asyncProductRepository = asyncProductRepository;
        }
        public async Task<List<GetProductListDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var items = (await _asyncProductRepository.GetAllAsync())
                .OrderBy(x => x.Name);
            var itemsDto = _mapper.Map<List<GetProductListDto>>(items);
            return itemsDto;
        }
    }


}
