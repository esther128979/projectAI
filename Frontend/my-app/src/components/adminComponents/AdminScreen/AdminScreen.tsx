import { FC, useState } from "react";
import logo from 'logo.png';
import LogoutIcon from '@mui/icons-material/Logout';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import ReceiptIcon from '@mui/icons-material/Receipt';
import { AppBar, Toolbar, Button, Typography, Tab, Tabs, IconButton, Tooltip, TextField } from "@mui/material";
import { Box, Container } from "@mui/system";
import { useNavigate, Routes, Route, useLocation } from "react-router-dom";
//import HomePage from "../HomePage/HomePage";
import MovieList from "../../commonComponents/MovieList/MovieList";
import { MovieObject, CategoryGroup, AgeGroup } from "../../../models/Movie";
import ChatIcon from '@mui/icons-material/Chat';
import CloseIcon from '@mui/icons-material/Close';
import { Paper, Collapse } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { Dashboard } from "../Dashboard/Dashboard";
import { UserCardList } from "../../../components/commonComponents/UserCardList/UserCardList";
interface AppContentProps { }

const AdminScreen: FC<{}> = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const getPageFromPath = (path: string) => {
    switch (path) {
      case '/':
        return 0;
      case '/users':
        return 1;
      case '/orders':
        return 2;
      case 'products':
        return 3;
      default:
        return -1; // שום טאב לא מסומן
    }
  };
  const page = getPageFromPath(location.pathname);
  const handleLogout = () => {
    // ניקוי נתונים אם צריך
    navigate('/login');
  };
  const handleChange = (event: React.SyntheticEvent, newPage: number) => {
    switch (newPage) {
      case 0: navigate('/'); break;
      case 1: navigate('/users'); break;
      case 2: navigate('/orders'); break;
      case 3: navigate('/products'); break;
      default: break;
    }
  };
  return (
    <Box  sx={{ display: 'flex', flexDirection: 'column', minHeight: '100vh' }}>
      <AppBar dir="rtl" position="static" sx={{ backgroundColor: '#fff', boxShadow: 'none' }}>
        <Toolbar sx={{ justifyContent: 'space-between', alignItems: 'center', padding: '8px 16px' }}>
          <Tooltip title="DosFlix">
            <IconButton onClick={() => navigate('/')} sx={{ color: "#c1dbca" }}>
              <img src={logo} alt="DosFlix Logo" style={{ height: 50, borderRadius: '50%' }} />
            </IconButton>
          </Tooltip>
          <Tabs
            value={page >= 0 && page <= 3 ? page : false}
            onChange={handleChange}
            textColor="inherit"
            TabIndicatorProps={{ style: { backgroundColor: '#7a7a7a' } }}
            sx={{
              '& .MuiTab-root': { color: '#666666', fontWeight: 'bold', minWidth: 90 },
              '& .Mui-selected': { color: '#7a7a7a' },
            }}
          >
            <Tab label="ראשי" />
            <Tab label="לקוחות" />
            <Tab label="הזמנות" />
            <Tab label="מוצרים" />
          </Tabs>

          <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
            <Tooltip title="התנתקות">
              <IconButton onClick={handleLogout} sx={{ color: "#c1dbca" }}>
                <LogoutIcon />
              </IconButton>
            </Tooltip>
          </Box>
        </Toolbar>
      </AppBar>
      <Container sx={{ flexGrow: 1, marginTop: '2rem', paddingLeft: '2rem', position: 'relative' }} maxWidth={false} disableGutters>
        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/users" element={<UserCardList />} />
          {/* <Route path="/" element={<Cart />} />
                          <Route path="/orders" element={<Orders />} />
                          <Route path="/about" element={<About />} />
                          <Route path="/login" element={<Login />} />
                          <Route path="/register" element={<Register />} /> */}
        </Routes>
      </Container>

    </Box>

  )
}
export default AdminScreen;
