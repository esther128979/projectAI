import {MovieObject } from "@/models/Movie";
import axios from "axios";


  export const getMovies = async ( )=> {
    axios.get('https://localhost:7229/DosFlix/Movies')
  .then(response => {
    return response.data;
  })
  .catch(error => {
    console.error('Error fetching movies:', error);
    return [];
    
  });
  };
   export const addMovie = async (newMovie : MovieObject )=> {
   axios.post('https://localhost:7229/DosFlix/Movies', newMovie, {
  headers: {
    'Content-Type': 'application/json',
  }
}).catch(error => {
    console.error('Error fetching movies:', error);
  });
  };
  export const updateMoviePartial = async (movieToUpdate: MovieObject) => {
  try {
    await axios.put(`https://localhost:7229/DosFlix/Movies/${movieToUpdate.Id}`, movieToUpdate, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
    console.log('Movie updated');
  } catch (error) {
    console.error('Error updating movie:', error);
  }
};