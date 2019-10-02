using System;
using GraphQL;
using GraphQL.Types;
using TestTennis.Application.Repositories;
using TestTennis.WebAPI.GraphQL.Types;

namespace TestTennis.WebAPI.GraphQL.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IReadOnlyTennisRepository repository)
        {
            FieldAsync<ListGraphType<PlayerType>>("players",
                resolve: async context =>
                {
                    return await repository.FindAll();
                });
            FieldAsync<PlayerType>("player",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "playerId" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("playerId");
                    var player = await repository.FindById(id);
                    if (player == null)
                        context.Errors.Add(new ExecutionError("Not found"));
                    return player;
                });
        }
    }
}
