import React from "react";

const GameList = ({ games }) => {
  if (!games.length) {
    return <div className="text-center text-gray-400">No games found.</div>;
  }

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
      {games.map((game) => (
        <div key={game.id} className="bg-white p-4 rounded-2xl shadow-md">
          <h2 className="text-xl font-bold">{game.title}</h2>
          <p className="text-sm text-gray-500 mb-1">Platform: {game.platform}</p>
          <p className="text-sm text-yellow-600">⭐ {game.averageRating?.toFixed(1) ?? 'N/A'}</p>
        </div>
      ))}
    </div>
  );
};

export default GameList;
