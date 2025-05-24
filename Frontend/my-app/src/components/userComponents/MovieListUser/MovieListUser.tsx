
// // import React,{ FC, useState } from "react";
// // import { RootState } from "../../../myStore";
// // import { useDispatch, useSelector } from "react-redux";
// // import { MovieObject } from "../../../models/Movie";
// // import MovieCard from "../MovieCardUser/MovieCardUser";
// // import { Box, Button } from '@mui/material';
// // import AddIcon from '@mui/icons-material/Add';
// //  import { toast, ToastContainer } from 'react-toastify';
// // import { addToCart } from "../../../redux/cartSlice";

// // interface MovieListProps {
// //   movies: MovieObject[];
// // }

// // const MovieListUser: FC<MovieListProps> = ({ movies }) => {
// //     const [showMiniCart, setShowMiniCart] = useState(false);

// //   const user = useSelector((state: RootState) => state.auth);
// //    const dispatch = useDispatch();
// //   const cart = useSelector((state: any) => state.myCart.items|| []); // שליפת סל הקניות


// //   function handleOrderNow(movieId: number) {
// //       toast.success(` הזמנת סרט"${movieId}" `, {
// //       position: "top-center",
// //       autoClose: 2000,
// //       hideProgressBar: true,
// //       closeOnClick: true,
// //       pauseOnHover: false,
// //       draggable: false,
// //     });
// //   }


// //  function handleAddToCart(movie: MovieObject) {
// //     dispatch(addToCart(movie)); // הוספה לעגלה דרך Redux
// //      setShowMiniCart(true);
// //     // הסתרה אוטומטית אחרי 3 שניות
// //     setTimeout(() => {
// //       setShowMiniCart(false);
// //     }, 3000);
// //   }

// //   function handleAddMovie() {
// //     alert('פתיחת טופס הוספת סרט (או ניווט לדף מתאים)');
// //     // לדוגמה: navigate("/admin/movies/create");
// //   }

// //   return (
// //     <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
// //       <Box display="flex" flexWrap="wrap" justifyContent="center" gap={2}>
// //         {movies.map(movie => (
// //           <Box
// //             key={movie.Id}
// //             sx={{
// //               flexBasis: {
// //                 xs: '100%',
// //                 sm: 'calc(50% - 16px)',
// //                 md: 'calc(33.33% - 16px)',
// //                 lg: 'calc(25% - 16px)',
// //                 xl: 'calc(20% - 16px)',
// //               },
// //               maxWidth: '100%',
// //               minWidth: 250,
// //             }}
// //           >
// //             <MovieCard
// //               movie={movie}
// //               onOrderNow={handleOrderNow}
// //               onAddToCart={()=>handleAddToCart(movie)}
// //             />
// //           </Box>
// //         ))}
// //       </Box>
// //    <ToastContainer />
// //  {showMiniCart && (
// //         <div className="mini-cart-popup">
// //           <h4>🛒 סל הקניות שלך</h4>
// //           {cart.map((item: any) => (

// //             <div key={item.Id} className="mini-cart-item">
// //                <img
// //                   src={item.Image}
// //                   alt={item.Name}
// //                   className="cart-item-image"
// //                 />
// //               {item.Name} x {item.quantity}
// //             </div>
// //           ))}
// //         </div>
// //       )}

// //     </div>
// //   );
// // };
// // export default MovieListUser;
// //את רוצה לנסות לשים פה את השני?
// //
// // import { FC } from "react";
// // import { MovieObject } from "../../../models/Movie";
// // import MovieCard from "../MovieCard/MovieCard";
// // import { Box } from '@mui/material';

// // interface MovieListProps {
// //   movies: MovieObject[];
// // }

// // const MovieList: FC<MovieListProps> = ({ movies }) => {

// //   function handleOrderNow(movieId: number) {
// //     alert('הזמנה של סרט עם id: ' + movieId);
// //   }

// //   function handleAddToCart(movieId: number) {
// //     alert('הוסף לעגלה סרט עם id: ' + movieId);
// //   }

// //   return (
// //     <>
// //     <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
// //       <Box
// //         display="flex"
// //         flexWrap="wrap"
// //         justifyContent="center"
// //         gap={2}
// //       >
// //         {movies.map(movie => (
// //           <Box
// //             key={movie.Id}
// //             sx={{
// //               flexBasis: {
// //                 xs: '100%',
// //                 sm: 'calc(50% - 16px)',
// //                 md: 'calc(33.33% - 16px)',
// //                 lg: 'calc(25% - 16px)',
// //                 xl: 'calc(20% - 16px)',
// //               },
// //               maxWidth: '100%',
// //               minWidth: 250,
// //             }}
// //           >
// //             <MovieCard
// //               movie={movie}
// //               onOrderNow={handleOrderNow}
// //               onAddToCart={handleAddToCart}
// //             />
// //           </Box>
// //         ))}
// //       </Box>


// //     </div>
// //     </>
// //   );
// // };

// // export default MovieList;
// //
// import { FC } from "react";
// import { useSelector } from "react-redux";
// import { RootState } from "../../../myStore";

// import { MovieObject } from "../../../models/Movie";
// import MovieCard from "../MovieCardUser/MovieCardUser";
// import { Box, Button } from '@mui/material';
// import AddIcon from '@mui/icons-material/Add';

// interface MovieListProps {
//   movies: MovieObject[];
// }

// const MovieListUser: FC<MovieListProps> = ({ movies }) => {
//   const user = useSelector((state: RootState) => state.auth);

//   function handleOrderNow(movieId: number) {
//     alert('הזמנה של סרט עם id: ' + movieId);
//   }

//   function handleAddToCart(movieId: number) {
//     alert('הוסף לעגלה סרט עם id: ' + movieId);
//   }

//   function handleAddMovie() {
//     alert('פתיחת טופס הוספת סרט (או ניווט לדף מתאים)');
//     // לדוגמה: navigate("/admin/movies/create");
//   }

//   return (
//     <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
//       {user?.role === 'admin' && (
//         <Box display="flex" justifyContent="flex-end" mb={2}>
//           <Button
//             variant="contained"
//             color="primary"
//             startIcon={<AddIcon />}
//             onClick={handleAddMovie}
//             sx={{
//               fontWeight: 'bold',
//               textTransform: 'none',
//               backgroundColor: '#740d5c',
//               '&:hover': {
//                 backgroundColor: '#9a1c78',
//                 transform: 'scale(1.03)',
//               },
//               borderRadius: 2,
//               px: 3,
//               py: 1.2
//             }}
//           >
//             הוסף סרט
//           </Button>
//         </Box>
//       )}

//       <Box display="flex" flexWrap="wrap" justifyContent="center" gap={2}>
//         {movies.map(movie => (
//           <Box
//             key={movie.Id}
//             sx={{
//               flexBasis: {
//                 xs: '100%',
//                 sm: 'calc(50% - 16px)',
//                 md: 'calc(33.33% - 16px)',
//                 lg: 'calc(25% - 16px)',
//                 xl: 'calc(20% - 16px)',
//               },
//               maxWidth: '100%',
//               minWidth: 250,
//             }}
//           >
//             <MovieCard
//               movie={movie}
//               onOrderNow={handleOrderNow}
//               onAddToCart={handleAddToCart}
//             />
//           </Box>
//         ))}
//       </Box>
//     </div>
//   );
// };

// export default MovieListUser;
import { FC, useState } from "react";
import { RootState } from "../../../myStore";
import { useDispatch, useSelector } from "react-redux";
import { MovieObject } from "../../../models/Movie";
import MovieCardUser from "../MovieCardUser/MovieCardUser";
import { Box, Button } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { toast, ToastContainer } from 'react-toastify';
import { addToCart } from "../../../redux/cartSlice";

interface MovieListProps {
  movies: MovieObject[];
}

const MovieListUser: FC<MovieListProps> = ({ movies }) => {
  const [showMiniCart, setShowMiniCart] = useState(false);

  //const user = useSelector((state: RootState) => state.auth);
  const dispatch = useDispatch();
  const cart = useSelector((state: RootState) => state.myCart.items || []);

  function handleOrderNow(movieId: number) {
    toast.success(`הזמנת סרט "${movieId}"`, {
      position: "top-center",
      autoClose: 2000,
      hideProgressBar: true,
      closeOnClick: true,
      pauseOnHover: false,
      draggable: false,
    });
  }

  function handleAddToCart(movie: MovieObject) {
    dispatch(addToCart(movie));
    setShowMiniCart(true);
     setTimeout(() => {
    setShowMiniCart(false);
    }, 3000);
    console.log('כאן המוצרים')
  }

  return (
    <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
      <Box display="flex" flexWrap="wrap" justifyContent="center" gap={2}>
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
            }} >
            {<MovieCardUser
              movie={movie}
              onOrderNow={handleOrderNow}
              onAddToCart={() => handleAddToCart(movie)}
            />}
          </Box>
        ))}
      </Box>
        {showMiniCart && (
        <div className="mini-cart-popup">
          <h4>🛒 סל הקניות שלך</h4>
          {cart.map((item: any) => (
            <div key={item.Id} className="mini-cart-item">
              <img src={item.Image} alt={item.Name} className="cart-item-image" />
              {item.Name} x {item.quantity}
            </div>
          ))}
          </div>)}
    </div>
  );
};

export default MovieListUser;


