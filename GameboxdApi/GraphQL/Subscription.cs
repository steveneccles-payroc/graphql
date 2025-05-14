using GameboxdApi.Models;

namespace GameboxdApi.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic]
    public GameReview OnReviewAdded([EventMessage] GameReview review) => review;
}