// import React from 'react';
// import logo from './logo.svg';
// import './App.css';
// import MovieList from './components/MovieList/MovieList';
// import { AppBar, Box, Container, Toolbar, Typography } from '@mui/material';
// import HomePage from './components/HomePage/HomePage';
// import {UserProfileCard} from './components/UserProfileCard/UserProfileCard'

// function App() {
//   return (
//     <Box sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
//   <AppBar position="static" style={{ backgroundColor: '#fff', boxShadow: 'none' }}>
//   <Toolbar style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', padding: '16px' }}>
//     <Typography variant="h4" style={{ fontWeight: 'bold', color: '#2c3e50' }}>
//       MOVIES4ALL
//     </Typography>
//     <Typography variant="h6" style={{ marginTop: 8, color: '#7f8c8d', fontStyle: 'italic' }}>
//     Movies for all times and seasons   </Typography>
//   </Toolbar>
// </AppBar>
//   <Container sx={{ flexGrow: 1, marginTop: '2rem' }}>
//     <HomePage />
//   </Container>

//   <Box sx={{ flexShrink: 0, textAlign: 'center', padding: 2, background: '#f5f5f5', borderTop: '1px solid #ddd' }}>
//     <Typography variant="body2" color="textSecondary">
//       All rights reserved &copy; 2025 | Movies for the Haredi Community | Developed by Programming Group 3 Seminar Beit Yaakov Bnot Elisheva
//     </Typography>
//   </Box>
// </Box>  );
// }

// export default App;
import { useState } from 'react';
import './App.css';
import { Route, Routes } from 'react-router';

import HomePage from './components/HomePage/HomePage';
import {LogIn} from './components/LogIn/LogIn';
import { NotFound } from './components/NotFound/NotFound';
import { AdminScreen } from './components/AdminScreen/AdminScreen';
import UserCardList  from './components/UserCardList/UserCardList';
import {User} from './models/User';

const arrayOfUsers: User[] = [
  {
    Id: 45,
    Name: "לאה כהן",
    Email: "lea@example.com",
    Phone: "052-1234567",
  },
  {
    Id:4,
    Name: "חיים לוי",
    Email: "chaim@example.com",
    Phone: "052-9876543",
  },
];
function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  return (
    <div className='row'>
    {isLoggedIn ? (
      <Routes>
        {/* <Route path='/' element={<LogIn  onLogin={() => setIsLoggedIn(true)}  />} /> */}
        <Route path="home" element={<HomePage />} >
          {/* <Route path='' element={<div style={{ width: '101vw', height: '100vh', margin: 0, padding: 0 }}>
            <img
              src="https://img.freepik.com/free-vector/gradient-bright-color-background_23-2149365050.jpg?ga=GA1.1.1115303456.1707422680&semt=ais_hybrid&w=740"
              alt="background"
              style={{ width: '100%', height: '100%', objectFit: 'cover' }}
            />
          </div>} /> */}
          {/* <Route path='admin' element={<Activities />} /> */}
        </Route>
        <Route path='admin' element={<UserCardList users={arrayOfUsers} />
} />
        <Route path='*' element={<NotFound></NotFound>}></Route>
      </Routes>
    ) :
      (<LogIn onLogin={() => setIsLoggedIn(true)} />)}
  </div>
  );
}

export default App;
