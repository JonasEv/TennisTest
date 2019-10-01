using System;
using GraphQL.Types;
using TestTennis.Application.DTOs;

namespace TestTennis.WebAPI.GraphQL.Types
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id");
            Field(x => x.Firstname).Description("Firstname");
            Field(x => x.Lastname).Description("Lastname");
        }
    }
}
