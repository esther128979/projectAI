
import './App.css';
import React from 'react';
import AppContent from './components/userComponents/AppContent/AppContent';
import { Routes, Route, useNavigate, Navigate } from "react-router-dom";
import { LogIn } from './components/commonComponents/LogIn/LogIn';
import { Dashboard } from './components/adminComponents/Dashboard/Dashboard';
import { useSelector } from 'react-redux';
import { myStore, RootState } from './myStore';
import AdminScreen from "./components/adminComponents/AdminScreen/AdminScreen"
// import { UserCardList } from './components/Cart/';
import Cart from './components/Cart/Cart';

const App = () => {

  const user = useSelector((state: RootState) => state.auth);
   console.log("USER STATE:", user);
  const isLoggedIn = user && user.role;

  return (
    <Routes>
      <Route path="/login" element={<LogIn />} />
      <Route
        path="/*"
        element={
          isLoggedIn ? (
            user.role === 'admin' ? <AdminScreen /> : <AppContent />
          ) : (
            <LogIn />
          )
        }
      />

    </Routes>
  );
};
 export default App;
