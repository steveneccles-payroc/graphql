import React, { useState, useEffect } from "react";
import {
  ApolloClient,
  InMemoryCache,
  ApolloProvider,
  useQuery,
  gql,
} from "@apollo/client";

const client = new ApolloClient({
  uri: "http://localhost:5103/graphql",
  cache: new InMemoryCache(),
});

const GET_GAMES = gql`
  query GetGames($search: String!) {
    games(search: $search) {
      id
      title
      coverImage
      platforms
    }
  }
`;

function GameCard({ game }) {
  return (
    <div className="bg-white rounded-2xl shadow p-4 flex gap-4 max-w-md w-full">
      <img
        src={game.coverImage}
        alt={game.title}
        className="w-24 h-32 object-cover rounded-lg"
      />
      <div className="flex flex-col">
        <h2 className="text-xl font-bold">{game.title}</h2>
        <p className="text-sm text-gray-500">{game.platform}</p>
        <p className="text-yellow-600 font-semibold">Rating: {game.rating}/10</p>
        <p className="text-sm mt-2 text-gray-700">{game.review}</p>
      </div>
    </div>
  );
}

function GameList() {
  const [searchTerm, setSearchTerm] = useState("");
  const [searchQuery, setSearchQuery] = useState("");

  const { loading, error, data, refetch } = useQuery(GET_GAMES, {
    variables: { search: searchQuery },
  });

  useEffect(() => {
    refetch({ search: searchQuery });
  }, [searchQuery, refetch]);

  return (
    <div className="flex flex-col items-center p-4 space-y-6">
      <div className="flex gap-2 w-full max-w-md">
        <input
          type="text"
          placeholder="Search games..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="flex-1 p-2 rounded border border-gray-300"
        />
        <button
          onClick={() => setSearchQuery(searchTerm)}
          className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700"
        >
          Search
        </button>
      </div>

      {loading && <p>Loading games...</p>}
      {error && <p className="text-red-500">Error loading games.</p>}

      <div className="grid gap-4 w-full max-w-md">
        {data?.games.map((game) => (
          <GameCard key={game.id} game={game} />
        ))}
      </div>
    </div>
  );
}

export default function App() {
  return (
    <ApolloProvider client={client}>
      <main className="min-h-screen bg-gray-100">
        <h1 className="text-3xl font-bold text-center pt-8 pb-4">Gameboxd</h1>
        <GameList />
      </main>
    </ApolloProvider>
  );
}
