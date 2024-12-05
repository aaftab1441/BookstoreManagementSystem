using Backend.Models;
using BookstoreClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace BookstoreClient.DataAccess
{
    public class BookService : BaseGraphQLService
    {
        public BookService() : base("https://localhost:7112/graphql/") { }

        public async Task<List<BookDto>> GetBooks()
        {
            var query = new GraphQLRequest
            {
                Query = @"query {
                            getBooks {
                                id
                                title
                                genre
                            }
                        }"
            };

            return await ExecuteQueryAsync<GetBooksModel>(query).ContinueWith(r => r.Result.GetBooks);
        }

        public async Task<BookDto> GetBookById(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"query($id: Int!) {
                    getBookById(id: $id) {
                        id
                        title
                        authorId
                        genre
                    }
                }",
                Variables = new { id }
            };

            return await ExecuteQueryAsync<GetBookByIdModel>(query).ContinueWith(r => r.Result.GetBookById);
        }

        public async Task<BookDto> AddBook(BookDto book)
        {
            if (book.AuthorId == 0)
            {
                throw new ArgumentException("Author is required");
            }

            var mutation = new GraphQLRequest
            {
                Query = @"mutation($book: BookDtoInput!) {
                            addBook(book: $book) {
                                id
                                title
                                genre
                                authorId
                            }
                        }",
                Variables = new { book }
            };

            return await ExecuteMutationAsync<AddBookModel>(mutation).ContinueWith(r => r.Result.AddBook);
        }

        public async Task<BookDto> UpdateBook(int id, BookDto book)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation($id: Int!, $updatedBook: BookDtoInput!) {
                            updateBook(id: $id, updatedBook: $updatedBook) {
                                id
                                title
                                genre
                                authorId
                            }
                        }",
                Variables = new { id, updatedBook = book }
            };

            return await ExecuteMutationAsync<UpdateBookModel>(mutation).ContinueWith(r => r.Result.UpdateBook);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation($id: Int!) {
                            deleteBook(id: $id)
                        }",
                Variables = new { id }
            };

            return await ExecuteMutationAsync<DeleteBookModel>(mutation).ContinueWith(r => r.Result.DeleteBook);
        }
    }
}