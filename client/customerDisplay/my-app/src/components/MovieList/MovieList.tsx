import { FC } from "react";
import { MovieObject } from "src/models/Movie";
import MovieCard from "../MovieCard/MovieCard";
import { Box } from '@mui/material';

interface MovieListProps {
  movies: MovieObject[];
}

const MovieList: FC<MovieListProps> = ({ movies }) => {

  function handleOrderNow(movieId: number) {
    alert('הזמנה של סרט עם id: ' + movieId);
  }

  function handleAddToCart(movieId: number) {
    alert('הוסף לעגלה סרט עם id: ' + movieId);
  }

  return (
    <div className="MovieList" style={{ padding: '20px' }}>
      <Box
        display="flex"
        flexWrap="wrap"
        gap={2}
        justifyContent="center"
      >
        {movies.map(movie => (
          <Box key={movie.Id} flexBasis="calc(25% - 16px)" minWidth="250px">
            <MovieCard
              movie={movie}
              onOrderNow={handleOrderNow}
              onAddToCart={handleAddToCart}
            />
          </Box>
        ))}
      </Box>
    </div>
  );
};

export default MovieList;
