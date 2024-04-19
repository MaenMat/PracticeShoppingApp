using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Categories.Commands
{
    public class CreateCategoryRequest : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
