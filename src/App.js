import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { ApolloProvider } from "@apollo/client";
import client from "./apolloClient"; // extract ApolloClient config into its own file
import GameList from "./components/GameList";
import GameDetail from "./components/GameDetail";
import AddGameForm from "./components/AddGameForm";
import { ReviewAlert } from "./components/ReviewAlert";


export default function App() {
  return (
    <ApolloProvider client={client}>
      <Router>
        <main className="min-h-screen bg-gray-100">
          <ReviewAlert />
          <h1 className="text-3xl font-bold text-center pt-8 pb-4">Gameboxd</h1>
          <Routes>
          <Route
            path="/"
            element={
              <div className="flex flex-col items-center space-y-6">
                <AddGameForm onGameAdded={() => window.location.reload()} />
                <GameList />
              </div>
            }
          />

            <Route path="/games/:id" element={<GameDetail />} />
          </Routes>
        </main>
      </Router>
    </ApolloProvider>
  );
}
