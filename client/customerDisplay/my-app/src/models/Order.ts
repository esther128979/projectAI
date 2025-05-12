export interface Order {
  id: number;
  date: string;
  movies: string[];
  price: number;
  paid: boolean;
}