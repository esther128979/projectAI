import React, { FC, useEffect, useState } from 'react';
import {
  List, ListItem, ListItemText, Button, CircularProgress,
  Typography, TextField, Dialog, DialogTitle, DialogContent, IconButton, Box,
  Tabs,
  Tab
} from '@mui/material';
import './HomePage.scss';
import MovieList from '../MovieList/MovieList';
import { AgeGroup, CategoryGroup, MovieObject } from '../../models/Movie';

interface HomePageProps {}
const moviesExemple: MovieObject[] = [
  {
    Id: 1,
    CategoryGroup: CategoryGroup.Children,
    AgeGroup: AgeGroup.Children,
    ThereIsWoman: true,
    Length: 90,
    AmountOfUses: 120,
    FilmProductionDate: new Date("2020-06-15"),
    MovieName: "The Magical Forest",
    MovieDescription: "An adventure of a young girl discovering a hidden forest.",
    MovieUrl: "https://example.com/magical-forest",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2021/03/DSC_05652-Edit-Edit-2-300x300.jpg",
    MoviePrice: 12.99
  },
  {
    Id: 2,
    CategoryGroup: CategoryGroup.Recipes,
    AgeGroup: AgeGroup.Adult,
    ThereIsWoman: false,
    Length: 45,
    AmountOfUses: 80,
    FilmProductionDate: new Date("2018-09-20"),
    MovieName: "Master Chef Secrets",
    MovieDescription: "Top chefs reveal their kitchen secrets.",
    MovieUrl: "https://example.com/master-chef",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2021/03/miki-spitzer-5-1-300x300.jpeg",
    MoviePrice: 9.99
  },
  {
    Id: 3,
    CategoryGroup: CategoryGroup.Nature,
    AgeGroup: AgeGroup.Teens,
    ThereIsWoman: true,
    Length: 60,
    AmountOfUses: 95,
    FilmProductionDate: new Date("2019-03-12"),
    MovieName: "Wildlife Wonders",
    MovieDescription: "A documentary exploring the wonders of wildlife.",
    MovieUrl: "https://example.com/wildlife-wonders",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2021/03/DSC_03034-Edit-3-300x300.jpg",
    MoviePrice: 11.49
  },
  {
    Id: 4,
    CategoryGroup: CategoryGroup.Plot,
    AgeGroup: AgeGroup.Adult,
    ThereIsWoman: true,
    Length: 110,
    AmountOfUses: 150,
    FilmProductionDate: new Date("2022-01-10"),
    MovieName: "The Hidden Truth",
    MovieDescription: "A suspenseful thriller uncovering a deep conspiracy.",
    MovieUrl: "https://example.com/hidden-truth",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2021/03/WhatsApp-Image-2021-03-18-at-20.28.32-4-300x300.jpeg",
    MoviePrice: 14.99
  },
  {
    Id: 5,
    CategoryGroup: CategoryGroup.Children,
    AgeGroup: AgeGroup.Babies,
    ThereIsWoman: false,
    Length: 30,
    AmountOfUses: 50,
    FilmProductionDate: new Date("2021-11-05"),
    MovieName: "Baby's First Adventure",
    MovieDescription: "A fun and educational animation for toddlers.",
    MovieUrl: "https://example.com/baby-adventure",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2023/03/DJI_0599-300x300.jpg",
    MoviePrice: 7.99
  },
  {
    Id: 6,
    CategoryGroup: CategoryGroup.Nature,
    AgeGroup: AgeGroup.GoldenAge,
    ThereIsWoman: true,
    Length: 85,
    AmountOfUses: 70,
    FilmProductionDate: new Date("2017-05-30"),
    MovieName: "Serene Landscapes",
    MovieDescription: "A calming journey through beautiful landscapes.",
    MovieUrl: "https://example.com/serene-landscapes",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2022/12/DSC_5202-Edit-300x300.jpg",
    MoviePrice: 10.99
  },
  {
    Id: 7,
    CategoryGroup: CategoryGroup.Recipes,
    AgeGroup: AgeGroup.Adult,
    ThereIsWoman: true,
    Length: 55,
    AmountOfUses: 100,
    FilmProductionDate: new Date("2023-02-18"),
    MovieName: "Vegan Delights",
    MovieDescription: "Learn to cook delicious vegan meals.",
    MovieUrl: "https://example.com/vegan-delights",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2023/07/DSC2490-Edit-3-300x300.jpg",
    MoviePrice: 13.49
  },
  {
    Id: 8,
    CategoryGroup: CategoryGroup.Plot,
    AgeGroup: AgeGroup.Teens,
    ThereIsWoman: false,
    Length: 130,
    AmountOfUses: 200,
    FilmProductionDate: new Date("2020-08-22"),
    MovieName: "The Lost Treasure",
    MovieDescription: "An action-packed adventure to find a legendary treasure.",
    MovieUrl: "https://example.com/lost-treasure",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2021/06/DSC_2724-Edit-2-300x300.jpg",
    MoviePrice: 15.99
  },
  {
    Id: 9,
    CategoryGroup: CategoryGroup.Children,
    AgeGroup: AgeGroup.Children,
    ThereIsWoman: true,
    Length: 75,
    AmountOfUses: 110,
    FilmProductionDate: new Date("2016-12-10"),
    MovieName: "Fairy Tale Chronicles",
    MovieDescription: "A magical journey through the world of fairy tales.",
    MovieUrl: "https://example.com/fairy-tales",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2024/04/52-300x300.jpg",
    MoviePrice: 14.49
  },
  {
    Id: 10,
    CategoryGroup: CategoryGroup.Recipes,
    AgeGroup: AgeGroup.Adult,
    ThereIsWoman: false,
    Length: 95,
    AmountOfUses: 25,
    FilmProductionDate: new Date("2015-04-10"),
    MovieName: "Cooking with Grandma",
    MovieDescription: "A heartwarming look at traditional home-cooked meals.",
    MovieUrl: "https://example.com/cooking-with-grandma",
    MovieImage: "https://mikispitzer.com/wp-content/uploads/2023/12/DSC8892-Recovered-300x300.jpg",
    MoviePrice: 9.99
  }
];
const HomePage: FC<HomePageProps> = () => {
    const [value, setValue] = useState(0);

    const [movies, setMovies] = useState<MovieObject[]>([]);
    const [moviesToView, setMoviesToView] = useState<MovieObject[]>(movies);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    useEffect(() => {
      setMoviesToView(movies);
    }, [movies]);
   const fetchStations = async () => {
      // setLoading(true);
      // setError('');
      setMovies(moviesExemple)
      // try {
      //   const response = await fetch('https://localhost:7183/Movies/DataRetrieval');//נא לעדכן לקישור הנכון לשרת
      //   if (!response.ok) {
      //     throw new Error('Failed to fetch stations');
      //   }
      //   const data: Movie[] = await response.json();
      //   setMovies(data);
      // } catch (err: any) {
      //   setError(err.message);
      // } finally {
      //   setLoading(false);
      // }
    };

    useEffect(() => {
      fetchStations();
    }, []);
    const handleChange = (_event: any, newValue: React.SetStateAction<number>) => {
      setValue(newValue);
    };
    const handleDataAdjusted = () => {

    };
  return <div className="HomePage">
    <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
        <Tab label="הצג הכל" />
        <Tab label="הצג נתונים מותאמים" />
      </Tabs>
    {loading && <CircularProgress />}
    {error && <Typography color="error">{error}</Typography>}
    {value === 0 &&  <MovieList movies={moviesToView}/>}
    {value === 1 && <div>הצגת נתונים מותאמים כאן</div>}

  </div>
};

export default HomePage;
