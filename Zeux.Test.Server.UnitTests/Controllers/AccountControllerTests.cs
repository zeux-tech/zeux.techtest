using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using Zeux.Test.Models;
using Zeux.Test.Server.Controllers;
using Zeux.Test.Server.Models.Account;
using Zeux.Test.Services;

namespace Zeux.Test.Server.UnitTests.Controllers
{
    public class AccountControllerTests
    {
        [Fact]
        public async void Token_ReturnsToken_WhenLoginAndPasswordIsValid()
        {
            // Arrange
            var login = "admin";
            var password = "admin";
            var role = "admin";

            var objectToReturn = new User
            {
                Login = login,
                Password = password,
                Role = role
            };

            var authOptions = new AuthOptions
            {
                Issuer = "Zeux.Test.Server",
                Audience = "https://localhost:44385/",
                Lifetime = 10,
                Key = "mysupersecret_secretkey!123"
            };

            var mockService = new Mock<IUserService>();
            mockService.Setup(service => service.FindUser(login, password))
                .ReturnsAsync(objectToReturn);

            var mockAuthOptions = new Mock<IOptions<AuthOptions>>();
            mockAuthOptions.Setup(options => options.Value).Returns(authOptions);

            var controller = new AccountController(mockService.Object, mockAuthOptions.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var tokenModel = new TokenModel { Username = login, Password = password };

            // Act
            await controller.Token(tokenModel);

            var tokenString = GetCookieValueFromResponse(controller.Response, "jwt-token");
            var token = new JwtSecurityToken(tokenString);

            // Assert
            Assert.Equal(authOptions.Issuer, token.Claims.First().Issuer);
            Assert.Equal(token.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value, login);
            Assert.Equal(token.Claims.First(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value, role);
        }

        string GetCookieValueFromResponse(HttpResponse response, string cookieName)
        {
            foreach (var headers in response.Headers.Values)
            foreach (var header in headers)
                if (header.StartsWith($"{cookieName}="))
                {
                    var p1 = header.IndexOf('=');
                    var p2 = header.IndexOf(';');
                    return header.Substring(p1 + 1, p2 - p1 - 1);
                }
            return null;
        }
    }
}
