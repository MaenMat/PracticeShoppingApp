using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShoppingApp.Application.Features.Categories.Dtos
{
    public class GetCategoryDetailsDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<GetCategoryProductDto> Products { get; set; }
    }
}
