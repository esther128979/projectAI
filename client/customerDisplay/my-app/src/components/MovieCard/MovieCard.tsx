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
import { FC } from "react";
import { MovieObject } from "src/models/Movie";

interface MovieCardProps {
  movie: MovieObject;
  onOrderNow: (movieId: number) => void;
  onAddToCart: (movieId: number) => void;
}

const MovieCard: FC<MovieCardProps> = ({ movie, onOrderNow, onAddToCart }) => {
  return (
    <Card
      sx={{
        width: 320,
        height: 490,
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between',
        boxShadow: 6,
        borderRadius: 4,
        marginBottom: 3,
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
            sx={{ fontSize: 14, lineHeight: 1.4 }}
          >
            {movie.Description}
          </Typography>
        </Box>

        <Box display="flex" justifyContent="space-between" alignItems="center" mt={1} dir="rtl">
          <Box display="flex" alignItems="center" gap={0.5}>
            <VisibilityIcon sx={{ fontSize: 18 }} />
            <Typography variant="body2" color="text.secondary" sx={{ fontSize: 13 }}>
              {movie.AmountOfViews}
            </Typography>
          </Box>
          <Box display="flex" alignItems="center" gap={0.5}>
            <AccessTimeIcon sx={{ fontSize: 18 }} />
            <Typography variant="body2" color="text.secondary" sx={{ fontSize: 13 }}>
              {movie.Duration} דקות
            </Typography>
          </Box>
        </Box>

        <Typography
          variant="h6"
          dir="rtl"
          mt={2}
          sx={{
            display: 'inline-block',
            px: 1.5,
            py: 0.5,
            backgroundColor: 'rgba(255,0,0,0.05)',
            borderRadius: 1,
            fontWeight: 'bold',
            color: 'secondary.main',
          }}
        >
          ₪{movie.Price}
        </Typography>
      </CardContent>

      <CardActions sx={{ justifyContent: 'space-around', paddingBottom: 2 }}>
        <Button
          size="medium"
          variant="contained"
          color="secondary"
          onClick={() => onOrderNow(movie.Id)}
          sx={{
            fontWeight: 'bold',
            px: 3,
            py: 1.2,
            textTransform: 'none',
            boxShadow: '0 4px 12px #c1dbca',
            transition: 'background-color 0.3s, transform 0.2s',
            '&:hover': {
              backgroundColor: '#c1dbca',
              transform: 'scale(1.1)',
              boxShadow: '0 6px 16px #c1dbca',
            }
          }}
        >
          הזמן עכשיו
        </Button>
        <Button
          size="medium"
          variant="outlined"
          color="secondary"
          startIcon={<ShoppingCartIcon />}
          onClick={() => onAddToCart(movie.Id)}
          sx={{
            fontWeight: 'bold',
            px: 3,
            py: 1.2,
            textTransform: 'none',
            borderColor: 'secondary.main',
            color: 'secondary.main',
            '&:hover': {
              backgroundColor: 'rgba(211, 47, 47, 0.1)',
              borderColor: '#c1dbca',
              color: '#c1dbca',
            }
          }}
        >
          הוסף לעגלה
        </Button>
      </CardActions>
    </Card>
  );
};

export default MovieCard;
