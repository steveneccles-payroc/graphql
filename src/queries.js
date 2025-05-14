import { gql } from '@apollo/client';

export const GET_GAMES = gql`
  query GetGames($search: String) {
    games(search: $search) {
      id
      title
      platform
      averageRating
      reviews {
        username
        rating
        review
      }
    }
  }
`;
