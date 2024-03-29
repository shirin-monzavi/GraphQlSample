﻿using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQlSample.Entities;
using GraphQlSample.Model;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace GraphQlSample
{
    public class OwnerConsumer
    {
        private readonly IGraphQLClient _client;
        public OwnerConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<ResponseOwnerCollectionType> GetAllOwners(GraphQLQuery graphQLQuery)
        {
            //query ownersQuery{ owners { id name  }  }

            var query = new GraphQLRequest
            {
                Query = graphQLQuery.Query,
            };

            var response = await _client.SendQueryAsync<ResponseOwnerCollectionType>(query);
            return response.Data;
        }

        public async Task<Owner> GetOwner(GraphQLQuery graphQLQuery, Guid id)
        {
            //query getOwner($ownerId:ID!){owner(ownerId:$ownerId){  id,address }}

            var query = new GraphQLRequest
            {
                Query = "query getOwner($ownerId:ID!){ owner(ownerId:$ownerId){ id, address }}",
                Variables = new { ownerId = id },
            };

            var response = await _client.SendQueryAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }

        public async Task<T> CreateOwner<T>(GraphQLQuery graphQLQuery)
        {

            //mutation($owner:ownerInput!){createOwner(owner:$owner){ name, address}}
            var query = new GraphQLRequest
            {
                Query = graphQLQuery.Query,
                Variables = new { owner = graphQLQuery.Variables }
            };

            var response = await _client.SendMutationAsync<T>(query);
            return response.Data;
            
            lock(_client)
            {

            }
           
        }

        public async Task<T> UpdateOwner<T>(Guid id, GraphQLQuery graphQLQuery)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                mutation($owner: ownerInput!, $ownerId: ID!){
                  updateOwner(owner: $owner, ownerId: $ownerId){
                    id,
                    name,
                    address
                  }
               }",
                Variables = new { owner = graphQLQuery.Variables, ownerId = id }
            };

            var response = await _client.SendMutationAsync<T>(query);
            return response.Data;
        }

        public async Task<T> DeleteOwner<T>(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        mutation($ownerId:ID!){
                        deleteOwner(ownerId: $ownerId){
                        id,
                        name,
                        address
                        }
                        }",
                Variables = new { ownerId = id }
            };

            var response = await _client.SendMutationAsync<T>(query);
            return response.Data;
        }
    }
}
