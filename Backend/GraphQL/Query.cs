using Backend.Data;
using Backend.Models;

namespace Backend.GraphQL
{
    public class Query
    {
        [GraphQLName("getBooks")]
        public IQueryable<BookDto> GetBooks([Service] BookstoreDbContext context) =>
            context.Books;

        [GraphQLName("getAuthors")]
        public IQueryable<AuthorDto> GetAuthors([Service] BookstoreDbContext context) =>
            context.Authors;

        [GraphQLName("getBookById")]
        public BookDto GetBookById(int id, [Service] BookstoreDbContext context)
        {
            return context.Books.FirstOrDefault(b => b.Id == id);
        }

        [GraphQLName("getAuthorById")]
        public AuthorDto GetAuthorById(int id, [Service] BookstoreDbContext context)
        {
            return context.Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}
