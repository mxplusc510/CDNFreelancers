using System.Collections.Generic;
using System.Threading.Tasks;
using CDNFreelancers.Controllers;
using CDNFreelancers.Data;
using CDNFreelancers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Xunit;

namespace CDNFreelancers.Tests
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly AppDbContext _context;

        public UsersControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _controller = new UsersController(_context, new MemoryCache(new MemoryCacheOptions()));
        }

        [Fact]
        public async Task GetUsers_ReturnsUsers()
        {
            // Arrange
            _context.Users.Add(new User
            {
                Username = "TestUser",
                Email = "test@example.com",
                Hobby = "Reading",
                PhoneNumber = "123-456-7890",
                Skillsets = "C#, SQL"
            });
            _context.SaveChanges();

            // Act
            var result = await _controller.GetUsers();

            // Assert
            var users = Assert.IsType<List<User>>(result.Value);
            Assert.Single(users);
        }
    }
}
