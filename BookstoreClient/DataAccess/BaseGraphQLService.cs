using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace BookstoreClient.DataAccess
{
    public abstract class BaseGraphQLService
    {
        protected readonly GraphQLHttpClient _client;

        protected BaseGraphQLService(string endpoint)
        {
            _client = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());
        }

        protected async Task<T> ExecuteQueryAsync<T>(GraphQLRequest request)
        {
            var response = await _client.SendQueryAsync<T>(request);
            return response.Data;
        }

        protected async Task<T> ExecuteMutationAsync<T>(GraphQLRequest request)
        {
            var response = await _client.SendMutationAsync<T>(request);
            return response.Data;
        }
    }
}
