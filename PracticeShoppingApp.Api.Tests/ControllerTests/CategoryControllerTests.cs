//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Text.Json;
//using PracticeShoppingApp.API.IntegrationTests.Base;
//using PracticeShoppingApp.Application.Features.Categories.Dtos;
//namespace PracticeShoppingApp.API.IntegrationTests.Controllers
//{

//    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
//    {
//        private readonly CustomWebApplicationFactory<Program> _factory;

//        public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
//        {
//            _factory = factory;
//        }

//        [Fact]
//        public async Task ReturnsSuccessResult()
//        {
//            var client = _factory.GetAnonymousClient();

//            var response = await client.GetAsync("/api/category/all");

//            response.EnsureSuccessStatusCode();

//            var responseString = await response.Content.ReadAsStringAsync();

//            var result = JsonSerializer.Deserialize<List<GetCategoryListDto>>(responseString);

//            Assert.IsType<List<GetCategoryListDto>>(result);
//            Assert.NotEmpty(result);
//        }
//    }
//}
