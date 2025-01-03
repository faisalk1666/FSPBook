using FSPBook.Data;
using FSPBook.Data.Entities;
using FSPBook.MVCPortal.Controllers;
using FSPBook.MVCPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSPBook.Tests
{
    public class HomeControllerTests
    {
        private readonly DbContextOptions<Context> _options;

        public HomeControllerTests()
        {
            _options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task Index_Returns_View_With_Posts()
        {
            using (var context = new Context(_options))
            {
                context.Post.AddRange(new List<Post>
                {
                    new Post { Id = 1, Content = "Test Post 1", DateTimePosted = DateTimeOffset.Now, Author = new Profile { FirstName = "John", LastName = "Doe" }},
                    new Post { Id = 2, Content = "Test Post 2", DateTimePosted = DateTimeOffset.Now.AddMinutes(-10), Author = new Profile { FirstName = "Jane", LastName = "Smith" }}
                });
                await context.SaveChangesAsync();
            }

            using (var context = new Context(_options))
            {
                var controller = new HomeController(null, context);

                var result = await controller.Index(skip: 0, take: 10);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<PostViewModel>(viewResult.Model);
                Assert.Equal(2, model.Posts.Count);
                Assert.Equal(2, model.TotalPosts);
            }
        }

        [Fact]
        public async Task Index_Returns_Limited_Number_Of_Posts()
        {
            using (var context = new Context(_options))
            {
                for (int i = 0; i < 15; i++)
                {
                    context.Post.Add(new Post
                    {
                        Content = $"Post {i}",
                        DateTimePosted = DateTimeOffset.Now.AddMinutes(-i),
                        Author = new Profile { FirstName = $"Author {i}", LastName = "Test" }
                    });
                }
                await context.SaveChangesAsync();
            }

            using (var context = new Context(_options))
            {
                var controller = new HomeController(null, context);

                var result = await controller.Index(skip: 0, take: 5);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<PostViewModel>(viewResult.Model);
                Assert.Equal(5, model.Posts.Count);
                Assert.True(model.Posts.Count < model.TotalPosts);
            }
        }

        [Fact]
        public async Task Index_Returns_Empty_View_If_No_Posts()
        {
            using (var context = new Context(_options))
            {
                var controller = new HomeController(null, context);
                var result = await controller.Index(skip: 0, take: 5);

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<PostViewModel>(viewResult.Model);
                Assert.Empty(model.Posts);
            }
        }
    }
}
