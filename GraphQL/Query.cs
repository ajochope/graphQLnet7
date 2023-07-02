namespace GraphQL
{
    public class Query
    {
        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello Query";
        }
        public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}