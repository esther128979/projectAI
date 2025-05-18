import { Movie } from "./Movie";

export interface Order {
  completed: boolean;
  id: number;
  date: string;
  movies: Movie[];
  price: number;
}