using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using TMS.Application.Services.Implementation;
using TMS.Domain.Entites.Requests.User;
using TMS.Domain.Repositories;
using TMS.Domain.ValueObjects;
using Xunit;

namespace PI_TMS.DomainTests;

public class UserTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

    [Fact]
    public async Task Should_User_Register_ResultOK()
    {
        // Arrange
        var request = new RegisterUserRequest(
            "Eduardo",
            "Vizicato",
            "eduardo@gmail.com",
            "edu123",
            "16993440158",
            new TaxIdVO("45554446809")
        );

        _userRepositoryMock
            .Setup(repo => repo.GetByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync((UserModel)null);

        _userRepositoryMock
            .Setup(repo => repo.AddAsync(It.IsAny<UserModel>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

        // Logger mock
        var loggerMock = new Mock<ILogger<UserService>>();

        var userStoreMock = new Mock<IUserStore<UserModel>>();
        var userManagerMock = new Mock<UserManager<UserModel>>(
            userStoreMock.Object,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null 
        );

        var service = new UserService(_userRepositoryMock.Object, loggerMock.Object, userManagerMock.Object);

        // Act
        var (result, response) = await service.RegisterUser(request);

        // Assert
        Assert.True(result.Succeeded, "Expected identity result to be successful");

        _userRepositoryMock.Verify(r => r.AddAsync(It.Is<UserModel>(u => u.Email == request.Email), request.Password), Times.Once);
    }

}