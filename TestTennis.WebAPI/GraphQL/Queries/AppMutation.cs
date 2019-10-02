using System;
using GraphQL;
using GraphQL.Types;
using TestTennis.Application.Repositories;
using TestTennis.WebAPI.GraphQL.Types;

namespace TestTennis.WebAPI.GraphQL.Queries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IWriteOnlyTennisRepository repository)
        {
            FieldAsync<PlayerType>(
                "deletePlayer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "playerId" }),
                resolve: async context =>
                {
                    var result = await repository.Delete(context.GetArgument<int>("playerId"));
                    if (result == null)
                        context.Errors.Add(new ExecutionError("Not found"));
                    return result;
                });
        }
    }
}
