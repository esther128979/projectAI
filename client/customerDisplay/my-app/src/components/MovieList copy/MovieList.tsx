import React, { FC, useState } from 'react';
import {
  List, Button, Typography, Dialog, DialogTitle, DialogContent, IconButton, Box
} from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import './MovieList.scss';
import { MovieObject } from '../../models/Movie';
import Movie from '../Movie/Movie';
import OrderDialog from '../OrderDialog/OrderDialog';
import { submitOrder } from '../../services/ordersService';



interface MovieListProps {
  movies: MovieObject[];
}

const MovieList: FC<MovieListProps> = ({ movies }) => {
  const [selectedMovie, setSelectedMovie] = useState<MovieObject | null>(null);
  const [orderDialogOpen, setOrderDialogOpen] = useState(false);

  const handleSelectMovie = (movie: MovieObject) => {
    setSelectedMovie(movie);
  };

  const handleOrder = () => {
    setOrderDialogOpen(true);
  };

  const handleOrderSubmit = async (email: string) => {
    if (selectedMovie) {
      const orderData = {
        email,
        movieName: selectedMovie.MovieName, // תוודא ששם הסרט נכון
      };

      try {
        await submitOrder(orderData);
        console.log("הזמנה נשלחה בהצלחה");
      } catch (error) {
        console.error("אירעה שגיאה בעת שליחת ההזמנה", error);
      }
    }

    setOrderDialogOpen(false);
    setSelectedMovie(null);
  };


  const handleOrderCancel = () => {
    setOrderDialogOpen(false);
  };

  return (
    <div className="MovieList">
      <List className="movie-container">
        {movies.map((m) => (
          <Movie key={m.Id} movie={m} handleSelectMovie={handleSelectMovie} />
        ))}
      </List>

      <Dialog open={!!selectedMovie} onClose={() => setSelectedMovie(null)} maxWidth="md" fullWidth>
        {selectedMovie && (
          <>
            <DialogTitle>
              <img
                src={selectedMovie.MovieImage}
                alt={selectedMovie.MovieName}
                style={{ width: '100%', maxHeight: '300px', objectFit: 'cover', borderRadius: '8px' }}
              />
              {selectedMovie.MovieName}
              <IconButton onClick={() => setSelectedMovie(null)} style={{ position: 'absolute', right: 10, top: 10 }}>
                <CloseIcon />
              </IconButton>
            </DialogTitle>
            <DialogContent style={{ maxHeight: '70vh', overflowY: 'auto' }}>
              <Typography>Film production date: {selectedMovie.FilmProductionDate.toLocaleDateString()}</Typography>
              <Typography>Category: {selectedMovie.CategoryGroup}</Typography>
              <Typography>Age: {selectedMovie.AgeGroup}</Typography>
              <Typography>There Is Woman: {selectedMovie.ThereIsWoman}</Typography>
              <Typography>Length: {selectedMovie.Length}</Typography>
              <Typography>Number of views: {selectedMovie.AmountOfUses}</Typography>
              <Typography>Movie Description: {selectedMovie.MovieDescription}</Typography>

              {/* עטיפת כפתורים ומחיר */}
              <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2, mt: 3 }}>
                <Box
                  sx={{
                    padding: '8px 16px',
                    backgroundColor: '#ffeb3b',
                    borderRadius: '8px',
                    color: '#333',
                    fontWeight: 'bold',
                    width: 'fit-content',
                  }}
                >
                  <Typography variant="h6" sx={{ m: 0 }}>
                    💰 {selectedMovie.MoviePrice} ₪
                  </Typography>
                </Box>
                <Box sx={{ display: 'flex', gap: 2, mt: 2 }}>
                  <Button variant="contained" onClick={handleOrder}>
                    Order Now
                  </Button>
                  <Button variant="outlined" onClick={handleOrder}>
                    Add to Bag
                  </Button>
                </Box>
              </Box>
            </DialogContent>
          </>
        )}
      </Dialog>

      <OrderDialog
        open={orderDialogOpen}
        onClose={handleOrderCancel}
        onSubmit={handleOrderSubmit}
      />
    </div>
  );
};

export default MovieList;
