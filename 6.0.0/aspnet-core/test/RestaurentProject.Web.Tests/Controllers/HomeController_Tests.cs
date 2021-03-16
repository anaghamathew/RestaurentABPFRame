using System.Threading.Tasks;
using RestaurentProject.Models.TokenAuth;
using RestaurentProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace RestaurentProject.Web.Tests.Controllers
{
    public class HomeController_Tests: RestaurentProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}