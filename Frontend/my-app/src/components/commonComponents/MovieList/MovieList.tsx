import { FC } from "react";
import { MovieObject } from "../../../models/Movie";
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
    <>
    <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
      <Box
        display="flex"
        flexWrap="wrap"
        justifyContent="center"
        gap={2}
      >
        {movies.map(movie => (
          <Box
            key={movie.Id}
            sx={{
              flexBasis: {
                xs: '100%',
                sm: 'calc(50% - 16px)',
                md: 'calc(33.33% - 16px)',
                lg: 'calc(25% - 16px)',
                xl: 'calc(20% - 16px)',
              },
              maxWidth: '100%',
              minWidth: 250,
            }}
          >
            <MovieCard
              movie={movie}
              onOrderNow={handleOrderNow}
              onAddToCart={handleAddToCart}
            />
          </Box>
        ))}
      </Box>


    </div>
    </>
  );
};

export default MovieList;
