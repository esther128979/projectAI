// import {
//   Button,
//   Card,
//   CardActions,
//   CardContent,
//   CardMedia,
//   Typography,
//   Box
// } from "@mui/material";
// import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
// import VisibilityIcon from '@mui/icons-material/Visibility';
// import AccessTimeIcon from '@mui/icons-material/AccessTime';
// import { FC } from "react";
// import { MovieObject } from "../../../models/Movie";

// interface MovieCardProps {
//   movie: MovieObject;
//   onOrderNow: (movieId: number) => void;
//   onAddToCart: (movieId: number) => void;
// }

// const MovieCard: FC<MovieCardProps> = ({ movie, onOrderNow, onAddToCart }) => {
//   return (
//     <Card
//       sx={{
//         backgroundColor: '#f8fafc',      // רקע בהיר
//         color: '#3e3e3e',                // צבע טקסט כהה
//         display: 'flex',
//         flexDirection: 'column',
//         justifyContent: 'space-between',
//         boxShadow: 6,
//         borderRadius: 4,
//         overflow: 'hidden',
//         transition: 'transform 0.3s',
//         '&:hover': {
//           transform: 'scale(1.05)',
//           boxShadow: 12,
//         }
//       }}
//     >
//       <CardMedia
//         component="img"
//         height="190"
//         image={movie.Image}
//         alt={movie.Name}
//       />
//       <CardContent sx={{ flexGrow: 1, overflow: 'hidden' }}>
//         <Typography
//           gutterBottom
//           variant="h6"
//           component="div"
//           dir="rtl"
//           sx={{
//             color: '#3e3e3e',
//             display: '-webkit-box',
//             WebkitLineClamp: 2,
//             WebkitBoxOrient: 'vertical',
//             overflow: 'hidden',
//           }}
//         >
//           {movie.Name}
//         </Typography>

//         <Box sx={{ height: 80, overflow: 'hidden', textOverflow: 'ellipsis' }}>
//           <Typography
//             variant="body2"
//             color="text.secondary"
//             dir="rtl"
//             sx={{ fontSize: 14, lineHeight: 1.4, color: '#3e3e3e' }}
//           >
//             {movie.Description}
//           </Typography>
//         </Box>

//         <Box display="flex" justifyContent="space-between" alignItems="center" mt={1} dir="rtl">
//           <Box display="flex" alignItems="center" gap={0.5}>
//             <VisibilityIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
//             <Typography variant="body2" color="text.secondary" sx={{ fontSize: 13, color: '#3e3e3e' }}>
//               {movie.AmountOfViews}
//             </Typography>
//           </Box>
//           <Box display="flex" alignItems="center" gap={0.5}>
//             <AccessTimeIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
//             <Typography variant="body2" color="text.secondary" sx={{ fontSize: 13, color: '#3e3e3e' }}>
//               {movie.Duration} דקות
//             </Typography>
//           </Box>
//         </Box>

//         <Typography
//           variant="h6"
//           dir="rtl"
//           mt={2}
//           sx={{
//             display: 'inline-block',
//             px: 1.5,
//             py: 0.5,
//             backgroundColor: '#b8399a41', 
//             borderRadius: 1,
//             fontWeight: 'bold',
//             color: '#3e3e3e',
//           }}
//         >
//           ₪{movie.Price}
//         </Typography>
//       </CardContent>

//       <CardActions sx={{ px: 2, pb: 2 }}>
//         <Box
//           display="flex"
//           flexDirection={{ xs: 'column', sm: 'row' }}
//           gap={1.5}
//           width="100%"
//         >
//           <Button
//             fullWidth
//             size="medium"
//             variant="contained"
//             onClick={() => onOrderNow(movie.Id)}
//             sx={{
//               fontWeight: 'bold',
//               px: 2,
//               py: 1.2,
//               textTransform: 'none',
//               boxShadow: '0 4px 12px #c1dbca',
//               transition: 'background-color 0.3s, transform 0.2s',
//               color: '#3e3e3e',
//               backgroundColor: '#f8fafc',
//               border: '1px solid #3e3e3e',
//               '&:hover': {
//                 backgroundColor: '#740d5c',
//                 color: '#f8fafc',
//                 transform: 'scale(1.03)',
//                 boxShadow: '0 6px 16px #3e3e3e',
//               }
//             }}
//           >
//             הזמן עכשיו
//           </Button>

//           <Button
//             fullWidth
//             size="medium"
//             variant="outlined"
//             startIcon={<ShoppingCartIcon sx={{ ml: 0.5, color: '#740d5c' }} />}
//             onClick={() => onAddToCart(movie.Id)}
//             sx={{
//               fontWeight: 'bold',
//               px: 2,
//               py: 1.2,
//               textTransform: 'none',
//               borderColor: '#740d5c',
//               color: '#740d5c',
//               backgroundColor: '#f8fafc',
//               '&:hover': {
//                 backgroundColor: '#b8399a41',
//                 transform: 'scale(1.03)',
//                 boxShadow: '0 6px 16px #3e3e3e',
               
//               }
//             }}
//           >
//             הוסף לעגלה
//           </Button>
//         </Box>
//       </CardActions>

//     </Card>
//   );
// };

// export default MovieCard;
import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
  Box
} from "@mui/material";
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import VisibilityIcon from '@mui/icons-material/Visibility';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import InfoIcon from '@mui/icons-material/Info';

import { FC } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../myStore";
import { MovieObject } from "../../../models/Movie";

interface MovieCardProps {
  movie: MovieObject;
  onOrderNow: (movieId: number) => void;
  onAddToCart: (movieId: number) => void;
  onEdit?: (movieId: number) => void;
  onDelete?: (movieId: number) => void;
}

const MovieCard: FC<MovieCardProps> = ({
  movie,
  onOrderNow,
  onAddToCart,
  onEdit,
  onDelete
}) => {
  const user = useSelector((state: RootState) => state.auth);
  const isAdmin = user?.role === 'admin';

  return (
    <Card
      sx={{
        backgroundColor: '#f8fafc',
        color: '#3e3e3e',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between',
        boxShadow: 6,
        borderRadius: 4,
        overflow: 'hidden',
        transition: 'transform 0.3s',
        '&:hover': {
          transform: 'scale(1.05)',
          boxShadow: 12,
        }
      }}
    >
      <CardMedia
        component="img"
        height="190"
        image={movie.Image}
        alt={movie.Name}
      />
      <CardContent sx={{ flexGrow: 1, overflow: 'hidden' }}>
        <Typography
          gutterBottom
          variant="h6"
          component="div"
          dir="rtl"
          sx={{
            color: '#3e3e3e',
            display: '-webkit-box',
            WebkitLineClamp: 2,
            WebkitBoxOrient: 'vertical',
            overflow: 'hidden',
          }}
        >
          {movie.Name}
        </Typography>

        <Box sx={{ height: 80, overflow: 'hidden', textOverflow: 'ellipsis' }}>
          <Typography
            variant="body2"
            color="text.secondary"
            dir="rtl"
            sx={{ fontSize: 14, lineHeight: 1.4, color: '#3e3e3e' }}
          >
            {movie.Description}
          </Typography>
        </Box>

        <Box display="flex" justifyContent="space-between" alignItems="center" mt={1} dir="rtl">
          <Box display="flex" alignItems="center" gap={0.5}>
            <VisibilityIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
            <Typography variant="body2" sx={{ fontSize: 13, color: '#3e3e3e' }}>
              {movie.AmountOfViews}
            </Typography>
          </Box>
          <Box display="flex" alignItems="center" gap={0.5}>
            <AccessTimeIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
            <Typography variant="body2" sx={{ fontSize: 13, color: '#3e3e3e' }}>
              {movie.Duration} דקות
            </Typography>
          </Box>
        </Box>

        <Typography
          variant="h6"
          dir="ltr"
          mt={2}
          sx={{
            display: 'inline-block',
            px: 1.5,
            py: 0.5,
            backgroundColor: '#b8399a41',
            borderRadius: 1,
            fontWeight: 'bold',
            color: '#3e3e3e',
            direction:"ltr",
            marginLeft:0
          }}
        >
          ₪{movie.Price}
        </Typography>
      </CardContent>

      <CardActions sx={{ px: 2, pb: 2 }}>
        <Box
          display="flex"
          flexDirection={{ xs: 'column', sm: 'row' }}
          gap={1.5}
          width="100%"
          flexWrap="wrap"
        >
          <Button
            fullWidth
            size="medium"
            variant="contained"
            onClick={() => onOrderNow(movie.Id)}
            sx={{
              fontWeight: 'bold',
              px: 2,
              py: 1.2,
              textTransform: 'none',
              boxShadow: '0 4px 12px #c1dbca',
              color: '#3e3e3e',
              backgroundColor: '#f8fafc',
              border: '1px solid #3e3e3e',
              '&:hover': {
                backgroundColor: '#740d5c',
                color: '#f8fafc',
                transform: 'scale(1.03)',
                boxShadow: '0 6px 16px #3e3e3e',
              }
            }}
          >
            הזמן עכשיו
          </Button>

          <Button
            fullWidth
            size="medium"
            variant="outlined"
            startIcon={<ShoppingCartIcon sx={{ ml: 0.5, color: '#740d5c' }} />}
            onClick={() => onAddToCart(movie.Id)}
            sx={{
              fontWeight: 'bold',
              px: 2,
              py: 1.2,
              textTransform: 'none',
              borderColor: '#740d5c',
              color: '#740d5c',
              backgroundColor: '#f8fafc',
              '&:hover': {
                backgroundColor: '#b8399a41',
                transform: 'scale(1.03)',
                boxShadow: '0 6px 16px #3e3e3e',
              }
            }}
          >
            הוסף לעגלה
          </Button>

          {isAdmin && (
            <>
              <Button
                fullWidth
                size="medium"
                variant="outlined"
                startIcon={<EditIcon />}
                onClick={() => onEdit?.(movie.Id)}
                sx={{
                  fontWeight: 'bold',
                  px: 2,
                  py: 1.2,
                  textTransform: 'none',
                  color: '#3e3e3e',
                  backgroundColor: '#e2e8f0',
                  '&:hover': {
                    backgroundColor: '#cbd5e1',
                    transform: 'scale(1.03)',
                  }
                }}
              >
                ערוך
              </Button>

              <Button
                fullWidth
                size="medium"
                variant="outlined"
                startIcon={<DeleteIcon />}
                onClick={() => onDelete?.(movie.Id)}
                sx={{
                  fontWeight: 'bold',
                  px: 2,
                  py: 1.2,
                  textTransform: 'none',
                  color: '#dc2626',
                  borderColor: '#dc2626',
                  backgroundColor: '#fef2f2',
                  '&:hover': {
                    backgroundColor: '#fee2e2',
                    transform: 'scale(1.03)',
                  }
                }}
              >
                מחק
              </Button>

              <Button
                fullWidth
                size="medium"
                variant="outlined"
                startIcon={<InfoIcon />}
                href={`/admin/movies/${movie.Id}`}
                sx={{
                  fontWeight: 'bold',
                  px: 2,
                  py: 1.2,
                  textTransform: 'none',
                  color: '#334155',
                  borderColor: '#334155',
                  backgroundColor: '#f1f5f9',
                  '&:hover': {
                    backgroundColor: '#e2e8f0',
                    transform: 'scale(1.03)',
                  }
                }}
              >
                פרטי הסרט
              </Button>
            </>
          )}
        </Box>
      </CardActions>
    </Card>
  );
};

export default MovieCard;
