using GameboxdApi.Models;

namespace GameboxdApi.GraphQL.Types;

public class GameType : ObjectType<Game>
{
    protected override void Configure(IObjectTypeDescriptor<Game> descriptor)
    {
        descriptor.Field(g => g.Id);
        descriptor.Field(g => g.Title);
        descriptor.Field(g => g.Platforms);
        descriptor.Field(g => g.CoverImage);
        descriptor.Field(g => g.Reviews);
        descriptor.Field(g => g.Year);

        descriptor
            .Field("averageRating")
            .Type<FloatType>()
            .Resolve(ctx =>
            {
                var reviews = ctx.Parent<Game>().Reviews;
                return reviews.Any() ? reviews.Average(r => r.Rating) : 0;
            });
    }
}