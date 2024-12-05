
using Backend.Data;
using Backend.GraphQL;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BookstoreDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<BookDto>()
                .AddType<AuthorDto>();

            var app = builder.Build();

            app.UseRouting()
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            app.Run();
        }
    }
}
