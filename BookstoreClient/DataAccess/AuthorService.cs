using Backend.Models;
using BookstoreClient.Model;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace BookstoreClient.DataAccess
{
    public class AuthorService : BaseGraphQLService
    {
        public AuthorService() : base("https://localhost:7112/graphql/") { }

        public async Task<List<AuthorDto>> GetAuthors()
        {
            var query = new GraphQLRequest
            {
                Query = @"query {
                            getAuthors {
                                id
                                name
                            }
                        }"
            };

            return await ExecuteQueryAsync<GetAuthorsModel>(query).ContinueWith(r => r.Result.GetAuthors);
        }
        public async Task<AuthorDto> GetAuthorById(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"query($id: Int!) {
                    getAuthorById(id: $id) {
                        id
                        name
                    }
                }",
                Variables = new { id }
            };

            return await ExecuteQueryAsync<GetAuthorByIdModel>(query).ContinueWith(r => r.Result.GetAuthorById);
        }
        public async Task<AuthorDto> AddAuthor(AuthorDto author)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation($author: AuthorDtoInput!) {
                            addAuthor(author: $author) {
                                id
                                name
                            }
                        }",
                Variables = new { author }
            };

            return await ExecuteMutationAsync<AddAuthorModel>(mutation).ContinueWith(r => r.Result.AddAuthor);
        }

        public async Task<AuthorDto> UpdateAuthor(int id, AuthorDto author)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation($id: Int!, $updatedAuthor: AuthorDtoInput!) {
                    updateAuthor(id: $id, updatedAuthor: $updatedAuthor) {
                        id
                        name
                    }
                }",
                Variables = new { id, updatedAuthor = author } // Change here
            };

            return await ExecuteMutationAsync<UpdateAuthorModel>(mutation).ContinueWith(r => r.Result.UpdateAuthor);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var mutation = new GraphQLRequest
            {
                Query = @"mutation($id: Int!) {
                            deleteAuthor(id: $id)
                        }",
                Variables = new { id }
            };

            return await ExecuteMutationAsync<DeleteAuthorModel>(mutation).ContinueWith(r => r.Result.DeleteAuthor);
        }
    }
}