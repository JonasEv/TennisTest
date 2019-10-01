using System;
using GraphQL;
using GraphQL.Types;
using TestTennis.WebAPI.GraphQL.Queries;

namespace TestTennis.WebAPI.GraphQL.Shemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
    }
}
