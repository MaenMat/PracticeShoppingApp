using MediatR;
using PracticeShoppingApp.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Categories.Queries
{
    public class GetCategoriesListRequest : IRequest<List<GetCategoryListDto>>
    {
    }
}
