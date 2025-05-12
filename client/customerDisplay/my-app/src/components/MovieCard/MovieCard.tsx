

// interface MovieListProps { 
//   movies:Movie[]
// }

// const MovieList: FC<MovieListProps> = ({movies}) => {

//   const [selectedMovie, setSelectedMovie] = useState<Movie | null>(null);


//   const handleSelectMovie = (movie: Movie) => {
//     setSelectedMovie(movie);
//   };
//   const handleOrder = (movie: Movie) => {
//     //כאן נגדיר מה יקרה בעת הזמנה
//   };



//   return (

//     <div className="MovieList">

//       <List className="movie-container">
//         {movies.map((movie) => (
//           <ListItem key={movie.Id} className="movie-item">
//             <img
//               src={movie.MovieImage}
//               alt={movie.MovieName}
//               style={{ width: 100, height: 100, borderRadius: 8, marginRight: 16 }}
//             />
//             <ListItemText
//               primary={
//                 <span dangerouslySetInnerHTML={{
//                   __html: movie.MovieName
//                 }} />
//               }
//               secondary={
//                 <span dangerouslySetInnerHTML={{
//                   __html: `Number of views ${movie.AmountOfUses}`
//                 }} />
//               }
//             />
//             <Button variant="outlined" onClick={() => handleSelectMovie(movie)}>
//               To view movie details and to order
//             </Button>
//           </ListItem>
//         ))}
//       </List>
//       <Dialog open={!!selectedMovie} onClose={() => { setSelectedMovie(null) }} maxWidth="md" fullWidth>
//         {selectedMovie && (
//           <>
//             <DialogTitle>
//               <img
//                 src={selectedMovie.MovieImage}
//                 alt={selectedMovie.MovieName}
//                 style={{ width: '100%', maxHeight: '300px', objectFit: 'cover', borderRadius: '8px' }}
//               />
//               {selectedMovie.MovieName}
//               <IconButton onClick={() => { setSelectedMovie(null) }} style={{ position: 'absolute', right: 10, top: 10 }}>
//                 <CloseIcon />
//               </IconButton>
//             </DialogTitle>
//             <DialogContent style={{ maxHeight: '70vh', overflowY: 'auto' }}>
//               <Typography>Film production date: {selectedMovie.FilmProductionDate.toLocaleDateString()}</Typography>
//               <Typography>Category: {selectedMovie.CategoryGroup}</Typography>
//               <Typography>Age: {selectedMovie.AgeGroup}</Typography>
//               <Typography>There Is Woman: {selectedMovie.ThereIsWoman}</Typography>
//               <Typography>Length: {selectedMovie.Length}</Typography>
//               <Typography>Number of views: {selectedMovie.AmountOfUses}</Typography>
//               <Typography>Movie Description: {selectedMovie.MovieDescription}</Typography>
//               <Box sx={{
//                 display: "inline-block",
//                 padding: "8px 16px",
//                 backgroundColor: "#ffeb3b",
//                 borderRadius: "8px",
//                 color: "#333",
//                 fontWeight: "bold"
//               }}>
//                 <Typography variant="h6">
//                   💰 {selectedMovie.MoviePrice} ₪
//                 </Typography>
//               </Box>
             
//               <Button variant="contained" style={{ marginRight: '1rem', marginTop: '1rem' }} onClick={()=>{handleOrder(selectedMovie)}}>
//                 Order Now
//               </Button>
           
             
//             </DialogContent>
//           </>
//         )}
//       </Dialog>
//     </div>
//   )
// };
// export default MovieList;



import './MovieCard.scss';
import { Movie, CategoryGroup, AgeGroup } from '../../models/Movie';
import './MovieCard.scss';


interface MovieCardProps { 
  movie:Movie
}

  export function MovieCard(props:MovieCardProps) {
  
  return (
    <div className="movie-card">
      <h2 className="title">{props.movie.Id}</h2>
      <div className="info-grid">
        <div><strong>📅</strong> {new Date(props.movie.FilmProductionDate).toLocaleDateString()}</div>
        <div><strong>🎞️</strong> {props.movie.CategoryGroup}</div>
        <div><strong>👤</strong> {props.movie.AgeGroup}</div>
        <div><strong>👩</strong> {props.movie.ThereIsWoman ? 'Yes' : 'No'}</div>
        <div><strong>⏱️</strong> {props.movie.Length} min</div>
        <div><strong>👁️</strong> {props.movie.AmountOfUses} views</div>
      </div>
      <p className="description">{props.movie.MovieDescription}</p>
    </div>
  );
};

