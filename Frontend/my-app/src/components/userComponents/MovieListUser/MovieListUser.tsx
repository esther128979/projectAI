// import { FC } from "react";
// import { MovieObject } from "../../../models/Movie";
// import MovieCard from "../MovieCard/MovieCard";
// import { Box } from '@mui/material';

// interface MovieListProps {
//   movies: MovieObject[];
// }

// const MovieList: FC<MovieListProps> = ({ movies }) => {

//   function handleOrderNow(movieId: number) {
//     alert('הזמנה של סרט עם id: ' + movieId);
//   }

//   function handleAddToCart(movieId: number) {
//     alert('הוסף לעגלה סרט עם id: ' + movieId);
//   }

//   return (
//     <>
//     <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
//       <Box
//         display="flex"
//         flexWrap="wrap"
//         justifyContent="center"
//         gap={2}
//       >
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
//     </>
//   );
// };

// export default MovieList;
import { FC } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../myStore";

import { MovieObject } from "../../../models/Movie";
import MovieCard from "../MovieCardUser/MovieCardUser";
import { Box, Button } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';

interface MovieListProps {
  movies: MovieObject[];
}

const MovieListUser: FC<MovieListProps> = ({ movies }) => {
  const user = useSelector((state: RootState) => state.auth);

  function handleOrderNow(movieId: number) {
    alert('הזמנה של סרט עם id: ' + movieId);
  }

  function handleAddToCart(movieId: number) {
    alert('הוסף לעגלה סרט עם id: ' + movieId);
  }

  function handleAddMovie() {
    alert('פתיחת טופס הוספת סרט (או ניווט לדף מתאים)');
    // לדוגמה: navigate("/admin/movies/create");
  }

  return (
    <div className="MovieList" style={{ padding: '10px', maxWidth: '100%', width: '100%' }}>
      {user?.role === 'admin' && (
        <Box display="flex" justifyContent="flex-end" mb={2}>
          <Button
            variant="contained"
            color="primary"
            startIcon={<AddIcon />}
            onClick={handleAddMovie}
            sx={{
              fontWeight: 'bold',
              textTransform: 'none',
              backgroundColor: '#740d5c',
              '&:hover': {
                backgroundColor: '#9a1c78',
                transform: 'scale(1.03)',
              },
              borderRadius: 2,
              px: 3,
              py: 1.2
            }}
          >
            הוסף סרט
          </Button>
        </Box>
      )}

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
  );
};

export default MovieListUser;
