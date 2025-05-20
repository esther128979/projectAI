
import './App.css';
import AppContent from './components/userComponents/AppContent/AppContent';
import { Routes, Route, useNavigate } from "react-router-dom";
import { LogIn } from './components/commonComponents/LogIn/LogIn';
import { Dashboard } from './components/adminComponents/Dashboard/Dashboard';
import { useSelector } from 'react-redux';
import { RootState } from './myStore';
import { useEffect } from 'react';
import AdminScreen from "./components/adminComponents/AdminScreen/AdminScreen"
export default function App() {
  const { isLoggedIn, role } = useSelector((state: RootState) => state.auth);
  const navigate = useNavigate();

  // useEffect(() => {
  //   if (!isLoggedIn || !role) {
  //     navigate("/login");
  //   } else if (role === "admin") {
  //     navigate("/admin");
  //   } else if (role === "user"){
  //     navigate("/user");
  //   }
  // }, [isLoggedIn, role]);

  return (
    // <Routes>
    //   <Route path="/login" element={<LogIn />} />
    //   <Route path="/admin" element={<AdminScreen />} />
    //   <Route path="/user" element={<AppContent />} />
    // </Routes>
    <AdminScreen></AdminScreen>
  );
}
