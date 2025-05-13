import React, { FC } from 'react';
import './Movie.scss';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import Button from '@mui/material/Button';
import { MovieObject } from 'src/models/Movie';

interface MovieProps {
  movie?: MovieObject;
  handleSelectMovie?: (movie: MovieObject) => void;
}

const Movie: FC<MovieProps> = ({ movie, handleSelectMovie }) => {
  if (!movie) return null;

  return (
    <ListItem key={movie.Id} className="movie-item">
      <img
        src={movie.MovieImage}
        alt={movie.MovieName}
        style={{ width: 100, height: 100, borderRadius: 8, marginRight: 16 }}
      />
      <ListItemText
        primary={
          <span
            dangerouslySetInnerHTML={{
              __html: movie.MovieName,
            }}
          />
        }
        secondary={
          <span
            dangerouslySetInnerHTML={{
              __html: `Number of views ${movie.AmountOfUses}`,
            }}
          />
        }
      />
      <Button variant="outlined" onClick={() => handleSelectMovie?.(movie)}>
        To view movie details and to order
      </Button>
    </ListItem>
  );
};

export default Movie;
