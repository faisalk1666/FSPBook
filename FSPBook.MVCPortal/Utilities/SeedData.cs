using FSPBook.Data;
using FSPBook.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FSPBook.MVCPortal.Utilities;
internal static class SeedData
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (var context = new Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Context>>()))
        {
            if (context.Profile.Count() == 0)
            {
                var profiles = new List<Profile> {
                    new Profile { Id = 1, FirstName = "Jane", LastName = "Doe", JobTitle = "Developer" },
                    new Profile { Id = 2, FirstName = "John", LastName = "Smith", JobTitle = "Consultant" },
                    new Profile { Id = 3, FirstName = "Maisie", LastName = "Jones", JobTitle = "Project Manager" },
                    new Profile { Id = 4, FirstName = "Jack", LastName = "Simpson", JobTitle = "Engagement Officer" },
                    new Profile { Id = 5, FirstName = "Sadie", LastName = "Williams", JobTitle = "Finance Director" },
                    new Profile { Id = 6, FirstName = "Pete", LastName = "Jackson", JobTitle = "Developer" },
                    new Profile { Id = 7, FirstName = "Sinead", LastName = "O'Leary", JobTitle = "Consultant" }
                };
                context.Profile.AddRange(profiles);

                var posts = new List<Post>
                {
                    new Post { Id = 1, Content = "Just finished my morning run along the beach. Feeling energized for the day ahead!", DateTimePosted = DateTimeOffset.Now.AddHours(-1), AuthorId = 1 },
                    new Post { Id = 2, Content = "Excited for my upcoming trip to Japan next month! Anyone have travel tips?", DateTimePosted = DateTimeOffset.Now.AddDays(-1), AuthorId = 2 },
                    new Post { Id = 3, Content = "Just tried out that new vegan restaurant downtown. Highly recommend their quinoa bowl!", DateTimePosted = DateTimeOffset.Now.AddDays(-2), AuthorId = 3 },
                    new Post { Id = 4, Content = "Looking forward to the weekend concert. Who else is going to see The Weeknd live?", DateTimePosted = DateTimeOffset.Now.AddDays(-3), AuthorId = 4 },
                    new Post { Id = 5, Content = "Just finished reading '1984' by George Orwell. Mind blown. What's everyone else reading lately?", DateTimePosted = DateTimeOffset.Now.AddDays(-4), AuthorId = 5 },
                    new Post { Id = 6, Content = "Planning a camping trip for next week. Any suggestions for good spots nearby?", DateTimePosted = DateTimeOffset.Now.AddDays(-5), AuthorId = 6 },
                    new Post { Id = 7, Content = "Just learned how to make homemade pizza dough from scratch. Game changer!", DateTimePosted = DateTimeOffset.Now.AddDays(-6), AuthorId = 7 },
                    new Post { Id = 8, Content = "Who else is excited about the new iPhone release? Thinking of upgrading...", DateTimePosted = DateTimeOffset.Now.AddDays(-7), AuthorId = 1 },
                    new Post { Id = 9, Content = "Just got back from an amazing yoga retreat. Feeling so centered and refreshed.", DateTimePosted = DateTimeOffset.Now.AddDays(-8), AuthorId = 2 },
                    new Post { Id = 10, Content = "Looking for book club recommendations. Has anyone read anything great recently?", DateTimePosted = DateTimeOffset.Now.AddDays(-9), AuthorId = 3 },
                    new Post { Id = 11, Content = "Just adopted a new furry friend from the shelter! Meet Max, the cutest golden retriever ever.", DateTimePosted = DateTimeOffset.Now.AddDays(-10), AuthorId = 4 },
                    new Post { Id = 12, Content = "Just started learning Spanish on Duolingo. Anyone fluent who can practice with me?", DateTimePosted = DateTimeOffset.Now.AddDays(-11), AuthorId = 5 },
                    new Post { Id = 13, Content = "Looking for recommendations on the best hiking trails near the city. Who's got some favorite spots?", DateTimePosted = DateTimeOffset.Now.AddDays(-12), AuthorId = 6 },
                    new Post { Id = 14, Content = "Just tried out that new coffee shop downtown. Their cold brew is amazing! Has anyone else been?", DateTimePosted = DateTimeOffset.Now.AddDays(-13), AuthorId = 7 },
                    new Post { Id = 15, Content = "Planning a surprise birthday party for my sister. Any creative ideas appreciated!", DateTimePosted = DateTimeOffset.Now.AddDays(-14), AuthorId = 1 },
                    new Post { Id = 16, Content = "Just finished binge-watching Stranger Things season 4. Mind blown! What did everyone else think?", DateTimePosted = DateTimeOffset.Now.AddDays(-15), AuthorId = 2 }
                };

                context.Post.AddRange(posts);

                context.SaveChanges();
            }
        }
    }

    private static string exampleText = "Lorem Ipsum is simply dummy text of the printing and typesetting " +
        "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an " +
        "unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived " +
        "not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.";
}
