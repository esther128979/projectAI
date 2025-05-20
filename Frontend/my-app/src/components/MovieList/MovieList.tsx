import { FC, useState } from "react";
import { MovieObject } from "../../models/Movie";
import MovieCard from "../MovieCard/MovieCard";
import { Box } from '@mui/material';
import { useDispatch, useSelector } from "react-redux";
import { addToCart } from "../../redux/cartSlice";
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; // עיצוב ברירת מחדל
import './MovieList.scss';

interface MovieListProps {
  movies: MovieObject[];
}

const MovieList: FC<MovieListProps> = ({ movies }) => {
  const dispatch = useDispatch();
    const cart = useSelector((state: any) => state.myCart.items); // שליפת סל הקניות

  const [showMiniCart, setShowMiniCart] = useState(false);

  function handleOrderNow(movieId: number) {
      toast.success(` הזמנת סרט"${movieId}" `, {
      position: "top-center",
      autoClose: 2000,
      hideProgressBar: true,
      closeOnClick: true,
      pauseOnHover: false,
      draggable: false,
    });
  }

  function handleAddToCart(movie: MovieObject) {
    dispatch(addToCart(movie)); // הוספה לעגלה דרך Redux
     setShowMiniCart(true);
    // הסתרה אוטומטית אחרי 3 שניות
    setTimeout(() => {
      setShowMiniCart(false);
    }, 3000);
  }

  return (
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
        onAddToCart={() => handleAddToCart(movie)} // חיבור לפונקציה של הוספה לעגלה
        />
    </Box>
  ))}
</Box>

      <ToastContainer />
 {showMiniCart && (
        <div className="mini-cart-popup">
          <h4>🛒 סל הקניות שלך</h4>
          {cart.map((item: any) => (
            
            <div key={item.Id} className="mini-cart-item">
               <img
                  src={item.Image}
                  alt={item.Name}
                  className="cart-item-image"
                />
              {item.Name} x {item.quantity}
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default MovieList;
