using E_Commerce.Domain.ControlAccess.Infos.Entities;
using E_Commerce.Domain.ControlAccess.Users.Entities;
using E_Commerce.Domain.ControlAccess.Users.Services;
using E_Commerce.DTOs.DTOs;
using E_Commerce.DTOs.ViewModels.ControlAccess;
using E_Commerce.Infra.Data;
using Moq;

namespace E_Commerce.Tests.Users
{
    public class UserServiceTests(GlobalTextFixture fixture) : IClassFixture<GlobalTextFixture>
    {
        private readonly GlobalTextFixture _fixture = fixture;


        [Fact]
        public async Task Test1()
        {

            var service = new UserService(_fixture.UserRepositoryMock.Object, _fixture.MapperMock.Object, _fixture.InfoServiceMock.Object, _fixture.UserFactoryMock.Object);

            var createUserViewModel = new CreateUserViewModel();

            var createdInfo = new Info();
            var createdUser = new User();

            var addressDto = new AddressDto(
                _fixture.Faker.Random.int(),
                _fixture.Faker.Date.Past(),
                _fixture.Faker.Date.Future(),
                _fixture.Faker.Address.StreetName(),
                _fixture.Faker.Address.BuildingNumber(),
                _fixture.Faker.Address.SecondaryAddress(),
                _fixture.Faker.Address.City(),
                _fixture.Faker.Address.State(),
                _fixture.Faker.Address.ZipCode(),
                _fixture.Faker.Random.Words()
            );

            var infoDto = new InfoDto(
                _fixture.Faker.Random.int(),
                _fixture.Faker.Date.Past(),
                _fixture.Faker.Date.Future(),
                _fixture.Faker.Phone.PhoneNumber(),
                _fixture.Faker.Internet.Email(),
                addressDto
            );

            var userDto = new UserDto(
                _fixture.Faker.Random.int(),
                _fixture.Faker.Date.Past(),
                _fixture.Faker.Date.Future(),
                _fixture.Faker.Name.FirstName(),
                _fixture.Faker.Name.LastName(),
                _fixture.Faker.Random.Int(1, 100),
               infoDto
            );

            _fixture.InfoServiceMock.Setup(s => s.CreateInfo(It.IsAny<CreateUpdateInfoViewModel>(), It.IsAny<CreateUpdateAddressViewModel>())).ReturnsAsync(createdInfo);
            _fixture.UserFactoryMock.Setup(f => f.Create(It.IsAny<CreateUserViewModel>(), It.IsAny<Info>())).Returns(createdUser);
            _fixture.MapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

            var result = await service.CreateUser(createUserViewModel);

            Assert.Equal(userDto, result);
            _fixture.UserRepositoryMock.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
            _fixture.UserRepositoryMock.Verify(r => r.Save(), Times.Once);

            using var context = new DataContext(_fixture.ContextOptions);
            var savedUser = await context.Users.FindAsync(createdUser.Id);
            Assert.NotNull(savedUser);
            Assert.Equal(createdUser.Id, savedUser.Id);
        }
    }
}