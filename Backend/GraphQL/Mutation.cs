using Backend.Data;
using Backend.Models;

namespace Backend.GraphQL
{
    // GraphQL/Mutation.cs
    public class Mutation
    {
        [GraphQLName("addBook")]
        public async Task<BookDto> AddBook(BookDto book, [Service] BookstoreDbContext context)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        [GraphQLName("addAuthor")]
        public async Task<AuthorDto> AddAuthor(AuthorDto author, [Service] BookstoreDbContext context)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }

        [GraphQLName("updateBook")]
        public async Task<BookDto> UpdateBook(int id, BookDto updatedBook, [Service] BookstoreDbContext context)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.AuthorId = updatedBook.AuthorId;
                book.Genre = updatedBook.Genre; // Update the Genre as well.
                await context.SaveChangesAsync();
            }
            return book;
        }

        [GraphQLName("updateAuthor")]
        public async Task<AuthorDto> UpdateAuthor(int id, AuthorDto updatedAuthor, [Service] BookstoreDbContext context)
        {
            var author = context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                author.Name = updatedAuthor.Name;
                await context.SaveChangesAsync();
            }
            return author;
        }

        [GraphQLName("deleteBook")]
        public async Task<bool> DeleteBook(int id, [Service] BookstoreDbContext context)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        [GraphQLName("deleteAuthor")]
        public async Task<bool> DeleteAuthor(int id, [Service] BookstoreDbContext context)
        {
            var author = context.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
