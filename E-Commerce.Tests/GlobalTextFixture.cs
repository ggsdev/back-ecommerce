global using Xunit;
using AutoMapper;
using Bogus;
using E_Commerce.Domain.ControlAccess.Infos.Interfaces;
using E_Commerce.Domain.ControlAccess.Users.Interfaces;
using E_Commerce.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Moq;

public class GlobalTextFixture : IDisposable
{
    public DbContextOptions<DataContext> ContextOptions { get; }
    public Mock<IUserRepository> UserRepositoryMock { get; }
    public Mock<IUserFactory> UserFactoryMock { get; }
    public Mock<IInfoService> InfoServiceMock { get; }
    public Mock<IMapper> MapperMock { get; }
    public Faker Faker { get; }

    public GlobalTextFixture()
    {
        ContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Faker = new Faker();

        UserRepositoryMock = new Mock<IUserRepository>();
        UserFactoryMock = new Mock<IUserFactory>();
        InfoServiceMock = new Mock<IInfoService>();
        MapperMock = new Mock<IMapper>();

        Seed();
    }

    private void Seed()
    {
        using var context = new DataContext(ContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Add entities here

        context.SaveChanges();
    }

    public void Dispose()
    {
        using var context = new DataContext(ContextOptions);
        context.Database.EnsureDeleted();
    }
}