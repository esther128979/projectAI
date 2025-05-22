import { FC } from "react";
import { MovieObject } from "../../../models/Movie";
import MovieCardClient from "../MovieCardUser/MovieCardUser";
import { Box, Typography } from "@mui/material";

interface MovieListClientProps {
  movies: MovieObject[];
  onOrderNow: (id: number) => void;
  onAddToCart: (id: number) => void;
}

const MovieListClient: FC<MovieListClientProps> = ({ movies, onOrderNow, onAddToCart }) => {
  return (
    <Box sx={{ padding: 3 }}>
      <Typography variant="h5" fontWeight="bold" mb={3} textAlign="center">
        סרטים זמינים
      </Typography>

      <Box display="flex" flexWrap="wrap" justifyContent="center" gap={2}>
        {movies.map((movie) => (
          <Box
            key={movie.Id}
            sx={{
              flexBasis: {
                xs: '100%',
                sm: 'calc(50% - 16px)',
                md: 'calc(33.33% - 16px)',
                lg: 'calc(25% - 16px)',
              },
              maxWidth: '100%',
              minWidth: 250,
            }}
          >
            <MovieCardClient
              movie={movie}
              onOrderNow={onOrderNow}
              onAddToCart={onAddToCart}
            />
          </Box>
        ))}
      </Box>
    </Box>
  );
};

export default MovieListClient;