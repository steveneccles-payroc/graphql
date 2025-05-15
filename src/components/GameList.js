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
    hearts
    reviews {  
      username
      rating
      }
    }
  }
`;

function renderStars(ratingOutOf10) {
    const rating = ratingOutOf10 / 2; // convert to 0–5 scale
    const fullStars = Math.floor(rating);
    const halfStar = rating % 1 >= 0.25 && rating % 1 < 0.75;
    const emptyStars = 5 - fullStars - (halfStar ? 1 : 0);
  
    return (
      <span className="text-yellow-500">
        {"★".repeat(fullStars)}
        {halfStar ? "½" : ""}
        {"☆".repeat(emptyStars)}
      </span>
    );
  }

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
        <div className="flex flex-col flex-1 justify-between">
          <div>
            <h2 className="text-xl font-bold">{game.title} ({game.year})</h2>
            <p className="text-sm text-gray-500">{game.platform}</p>
            <div className="text-sm text-yellow-600 font-semibold flex items-center gap-1">
              {renderStars(game.averageRating ?? 0)}
              <span className="ml-1 text-xs text-gray-600">
                ({(game.averageRating ?? 0).toFixed(1)}/10)
              </span>
            </div>
            <p className="text-sm mt-2 text-gray-700">{game.review}</p>
          </div>
          <div className="mt-2 text-sm text-pink-600 font-medium flex items-center gap-1">
            ❤️ {game.hearts} {game.hearts === 1 ? "heart" : "hearts"}
          </div>
        </div>
      </div>
    </Link>
  );
}

export default function GameList() {
  const [searchTerm, setSearchTerm] = useState("");
  const [searchQuery, setSearchQuery] = useState("");
  const [sortField, setSortField] = useState("title");

  const { loading, error, data, refetch } = useQuery(GET_GAMES, {
    variables: { search: searchQuery },
  });

  useEffect(() => {
    refetch({ search: searchQuery });
  }, [searchQuery, refetch]);

  const games = data?.games;

  const sortedGames = [...(data?.games || [])].sort((a, b) => {
    if (sortField === "title") {
      return a.title.localeCompare(b.title);
    } else if (sortField === "year") {
      return b.year - a.year;
    } else if (sortField === "averageRating") {
      return b.averageRating - a.averageRating;
    } else if (sortField === "hearts") {
      return b.hearts - a.hearts;
    }
    return 0;
  });

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

      <div className="flex gap-2 items-center w-full max-w-md">
  <label htmlFor="sort" className="text-sm font-medium text-gray-700">Sort by:</label>
  <select
    id="sort"
    value={sortField}
    onChange={(e) => setSortField(e.target.value)}
    className="p-2 rounded border border-gray-300"
  >
    <option value="title">Name</option>
    <option value="year">Year</option>
    <option value="averageRating">Average Rating</option>
    <option value="hearts">Hearts</option>
  </select>
</div>


      {loading && <p>Loading games...</p>}
      {error && <p className="text-red-500">Error loading games.</p>}



      <div className="grid gap-4 w-full max-w-md">
  {sortedGames.map((game) => (
    <GameCard key={game.id} game={game} />
  ))}
</div>
    </div>
  );
}
