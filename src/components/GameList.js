import React, { useState, useEffect } from "react";
import { useQuery, gql } from "@apollo/client";
import { Link } from "react-router-dom";

const GET_GAMES = gql`
  query GetGames($search: String!) {
    games(search: $search) {
    id
    coverImage
    title
    platforms
    year
    averageRating
    reviews {  
      username
      rating
      }
    }
  }
`;

function GameCard({ game }) {
  // Optionally calculate average score if ratings are present
  const averageScore =
    game.ratings && game.ratings.length > 0
      ? (
          game.ratings.reduce((sum, r) => sum + r.score, 0) / game.ratings.length
        ).toFixed(1)
      : null;

  return (
    <Link to={`/games/${game.id}`} className="hover:opacity-90 transition">
      <div className="bg-white rounded-2xl shadow p-4 flex gap-4 max-w-md w-full">
        <img
          src={game.coverImage}
          alt={game.title}
          className="w-24 h-32 object-cover rounded-lg"
        />
        <div className="flex flex-col">
          <h2 className="text-xl font-bold">{game.title} ({game.year})</h2>
          <p className="text-sm text-gray-500">
            {game.platforms?.join(", ") || "Unknown platform"}
          </p>
          <p className="text-yellow-600 font-semibold">
            Rating: {game.averageRating ?? "N/A"}/10
          </p>
          {game.ratings?.[0]?.review && (
            <p className="text-sm mt-2 text-gray-700">
              “{game.ratings[0].review}”
            </p>
          )}
        </div>
      </div>
    </Link>
  );
}

export default function GameList() {
  const [searchTerm, setSearchTerm] = useState("");
  const [searchQuery, setSearchQuery] = useState("");

  const { loading, error, data, refetch } = useQuery(GET_GAMES, {
    variables: { search: searchQuery },
  });

  useEffect(() => {
    refetch({ search: searchQuery });
  }, [searchQuery, refetch]);

  const games = data?.games;

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
        {Array.isArray(games) && games.length > 0 ? (
          games.map((game) => <GameCard key={game.id} game={game} />)
        ) : (
          !loading && <p className="text-gray-600 text-center">No games found.</p>
        )}
      </div>
    </div>
  );
}
