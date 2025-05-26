import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Typography,
  Box,
  TextField
} from "@mui/material";
import VisibilityIcon from '@mui/icons-material/Visibility';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

import { FC, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../myStore";
import { MovieObject } from "../../../models/Movie";

interface MovieCardProps {
  movie: MovieObject;
  onEdit: (updatedMovie: MovieObject) => void;
  onDelete: (movieId: number) => void;
}

const MovieCardAdmin: FC<MovieCardProps> = ({
  movie,
  onEdit,
  onDelete
}) => {
  const user = useSelector((state: RootState) => state.auth);
  const isAdmin = user?.role === 'admin';

  const [editMode, setEditMode] = useState(false);
  const [editedMovie, setEditedMovie] = useState({ ...movie });

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
        {editMode ? (
          <TextField
            fullWidth
            variant="outlined"
            size="small"
            value={editedMovie.Name}
            onChange={(e) => setEditedMovie({ ...editedMovie, Name: e.target.value })}
          />
        ) : (
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
        )}

        <Box sx={{ height: 80, overflow: 'hidden', textOverflow: 'ellipsis' }}>
          {editMode ? (
            <TextField
              fullWidth
              multiline
              rows={3}
              variant="outlined"
              size="small"
              value={editedMovie.Description}
              onChange={(e) => setEditedMovie({ ...editedMovie, Description: e.target.value })}
            />
          ) : (
            <Typography
              variant="body2"
              color="text.secondary"
              dir="rtl"
              sx={{ fontSize: 14, lineHeight: 1.4, color: '#3e3e3e' }}
            >
              {movie.Description}
            </Typography>
          )}
        </Box>

        <Box display="flex" justifyContent="space-between" alignItems="center" mt={1} dir="rtl">
          <Box display="flex" alignItems="center" gap={0.5}>
            <VisibilityIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
            <Typography variant="body2" sx={{ fontSize: 13, color: '#3e3e3e' }}>
              {movie.TotalViewers}
            </Typography>
          </Box>
          <Box display="flex" alignItems="center" gap={0.5}>
            <AccessTimeIcon sx={{ fontSize: 18, color: '#3e3e3e' }} />
            {editMode ? (
              <TextField
                variant="outlined"
                size="small"
                value={editedMovie.LengthMinutes}
                onChange={(e) => setEditedMovie({ ...editedMovie, LengthMinutes: +e.target.value })}
                sx={{ width: 60 }}
              />
            ) : (
              <Typography variant="body2" sx={{ fontSize: 13, color: '#3e3e3e' }}>
                {movie.LengthMinutes} דקות
              </Typography>
            )}
          </Box>
        </Box>

        <Box display="flex" justifyContent="flex-start" mt={2}>
          {editMode ? (
            <TextField
              variant="outlined"
              size="small"
              value={editedMovie.PriceBase}
              onChange={(e) => setEditedMovie({ ...editedMovie, PriceBase: +e.target.value })}
              sx={{ backgroundColor: '#b8399a41', borderRadius: 1 }}
            />
          ) : (
            <Typography
              variant="h6"
              dir="ltr"
              sx={{
                display: 'inline-block',
                px: 1.5,
                py: 0.5,
                backgroundColor: '#b8399a41',
                borderRadius: 1,
                fontWeight: 'bold',
                color: '#3e3e3e'
              }}
            >
              ₪{movie.PriceBase}
              המחיר משתנה בהתאם לכמות הצפיות
            </Typography>
          )}
        </Box>
      </CardContent>

      <CardActions sx={{ px: 2, pb: 2 }}>
        <Box
          display="flex"
          flexDirection={{ xs: 'column', sm: 'row' }}
          gap={1.5}
          width="100%"
          flexWrap="wrap"
        >
            <>
              {editMode ? (
                <>
                  <Button
                    fullWidth
                    size="medium"
                    variant="contained"
                    onClick={() => {
                      onEdit?.(editedMovie);
                      setEditMode(false);
                    }}
                  >
                    שמור
                  </Button>
                  <Button
                    fullWidth
                    size="medium"
                    variant="outlined"
                    onClick={() => {
                      setEditedMovie({ ...movie });
                      setEditMode(false);
                    }}
                  >
                    בטל
                  </Button>
                </>
              ) : (
                <>
                  <Button
                    fullWidth
                    size="medium"
                    variant="outlined"
                    startIcon={<EditIcon />}
                    onClick={() => setEditMode(true)}
                  >
                    ערוך
                  </Button>
                  <Button
                    fullWidth
                    size="medium"
                    variant="outlined"
                    startIcon={<DeleteIcon />}
                    onClick={() => onDelete?.(movie.Id)}
                  >
                    מחק
                  </Button>
                </>
              )}
            </>
          
        </Box>
      </CardActions>
    </Card>
  );
};

export default MovieCardAdmin;
