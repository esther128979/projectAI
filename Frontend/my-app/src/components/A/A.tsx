import React from 'react';
import {
  Box,
  CssBaseline,
  Drawer,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
  Toolbar,
  AppBar,
  Paper,
  Grid,
} from '@mui/material';
import {
  LineChart,
  Line,
  CartesianGrid,
  XAxis,
  YAxis,
  Tooltip,
  ResponsiveContainer,
  PieChart,
  Pie,
  Cell,
  BarChart,
  Bar,
} from 'recharts';
import Calendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';

const drawerWidth = 240;

const summaryData = {
  orders: 124,
  customers: 38,
  movies: 56,
  views: 1450,
};

const ordersGraphData = [
  { date: '14/05', orders: 10 },
  { date: '15/05', orders: 15 },
  { date: '16/05', orders: 12 },
  { date: '17/05', orders: 20 },
  { date: '18/05', orders: 18 },
  { date: '19/05', orders: 25 },
  { date: '20/05', orders: 22 },
];

const popularMoviesData = [
  { name: 'סרט 1', value: 40 },
  { name: 'סרט 2', value: 30 },
  { name: 'סרט 3', value: 20 },
  { name: 'סרט 4', value: 10 },
];

const newCustomersData = [
  { period: 'ינואר', customers: 5 },
  { period: 'פברואר', customers: 8 },
  { period: 'מרץ', customers: 12 },
  { period: 'אפריל', customers: 15 },
  { period: 'מאי', customers: 10 },
];

const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042'];

export function Dashboard() {
  return (
    <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed" sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            מסך מנהל
          </Typography>
        </Toolbar>
      </AppBar>
      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box' },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: 'auto' }}>
          <List>
            {['סיכום', 'הזמנות', 'לקוחות', 'סרטים', 'הגדרות'].map((text) => (
              <ListItem key={text} disablePadding>
                <ListItemButton>
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </Box>
      </Drawer>

      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        <Grid container spacing={3}>
          {/* כרטיסי סיכום */}
          <Grid item xs={12} sm={6} md={3}>
            <Paper sx={{ p: 2 }}>
              <Typography variant="h6">הזמנות</Typography>
              <Typography variant="h4" color="primary">
                {summaryData.orders}
              </Typography>
            </Paper>
          </Grid>

          <Grid item xs={12} sm={6} md={3}>
            <Paper sx={{ p: 2 }}>
              <Typography variant="h6">לקוחות</Typography>
              <Typography variant="h4" color="primary">
                {summaryData.customers}
              </Typography>
            </Paper>
          </Grid>
          <Grid item xs={12} sm={6} md={3}>
            <Paper sx={{ p: 2 }}>
              <Typography variant="h6">סרטים</Typography>
              <Typography variant="h4" color="primary">
                {summaryData.movies}
              </Typography>
            </Paper>
          </Grid>
          <Grid item xs={12} sm={6} md={3}>
            <Paper sx={{ p: 2 }}>
              <Typography variant="h6">כמות צפיות</Typography>
              <Typography variant="h4" color="primary">
                {summaryData.views}
              </Typography>
            </Paper>
          </Grid>

          {/* גרף הזמנות */}
          <Grid item xs={12} md={6}>
            <Paper sx={{ p: 2, height: 300 }}>
              <Typography variant="h6" gutterBottom>
                מגמת הזמנות (7 ימים אחרונים)
              </Typography>
              <ResponsiveContainer width="100%" height="100%">
                <LineChart data={ordersGraphData}>
                  <Line type="monotone" dataKey="orders" stroke="#1976d2" strokeWidth={3} />
                  <CartesianGrid stroke="#ccc" />
                  <XAxis dataKey="date" />
                  <YAxis />
                  <Tooltip />
                </LineChart>
              </ResponsiveContainer>
            </Paper>
          </Grid>

          {/* תרשים עוגה - הזמנות לפי סרטים פופולריים */}
          <Grid item xs={12} md={6}>
            <Paper sx={{ p: 2, height: 300 }}>
              <Typography variant="h6" gutterBottom>
                הזמנות לפי סרטים פופולריים
              </Typography>
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie
                    data={popularMoviesData}
                    dataKey="value"
                    nameKey="name"
                    cx="50%"
                    cy="50%"
                    outerRadius={80}
                    fill="#8884d8"
                    label
                  >
                    {popularMoviesData.map((entry, index) => (
                      <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                    ))}
                  </Pie>
                  <Tooltip />
                </PieChart>
              </ResponsiveContainer>
            </Paper>
          </Grid>

          {/* תרשים עמודות - לקוחות חדשים לפי תקופה */}
          <Grid item xs={12} md={6}>
            <Paper sx={{ p: 2, height: 300 }}>
              <Typography variant="h6" gutterBottom>
                לקוחות חדשים לפי תקופה
              </Typography>
              <ResponsiveContainer width="100%" height="100%">
                <BarChart data={newCustomersData}>
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="period" />
                  <YAxis />
                  <Tooltip />
                  <Bar dataKey="customers" fill="#1976d2" />
                </BarChart>
              </ResponsiveContainer>
            </Paper>
          </Grid>

          {/* לוח שנה עם משימות */}
          <Grid item xs={12} md={6}>
            <Paper sx={{ p: 2 }}>
              <Typography variant="h6" gutterBottom>
                לוח שנה עם משימות
              </Typography>
              <Calendar />
            </Paper>
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
}


// import React, { useState } from 'react';
// import {
//     CssBaseline,
//     Box,
//     Drawer,
//     AppBar,
//     Toolbar,
//     Typography,
//     IconButton,
//     Divider,
//     Grid,
//     Paper,
// } from '@mui/material';
// import MenuIcon from '@mui/icons-material/Menu';
// import { Calendar } from 'react-calendar';
// import { Order } from '../../models/Order'
// import {MovieObject} from '../../models/Movie'
// import 'react-calendar/dist/Calendar.css';
// import { OrderCard } from '../OrderCard/OrderCard';

// import {
//     ResponsiveContainer,
//     BarChart,
//     Bar,
//     XAxis,
//     YAxis,
//     Tooltip,
//     Legend,
//     CartesianGrid,
// } from 'recharts';

// const drawerWidth = 280;


// const ordersData: Order[] = [
//     { id: 1, date: '2025-05-21', completed: false, movies: [{Id:5, Name: 'סרט 1', Url: '#' }], price: 25.5 },
//     { id: 2, date: '2025-05-22', completed: true, movies: [{ Id:7,Name: 'סרט 2', Url: '#' }], price: 45 },
//     { id: 3, date: '2025-05-21', completed: false, movies: [{Id:9, Name: 'סרט 3', Url: '#' }], price: 35.3 },
//     { id: 4, date: '2025-05-23', completed: true, movies: [{ Id:11,Name: 'סרט 4', Url: '#' }], price: 50 },
// ];

// // נתוני גרף סטטוס הזמנות יומי (ניתן לשדרג בהתאם לדינמיות)
// const chartData = [
//     { name: '21/5', completed: 1, pending: 1 },
//     { name: '22/5', completed: 1, pending: 0 },
//     { name: '23/5', completed: 1, pending: 0 },
// ];

// export  function Dashboard() {
//     const [mobileOpen, setMobileOpen] = useState(false);
//     const [selectedDate, setSelectedDate] = useState<Date | null>(null);
//     const [orders, setOrders] = useState<Order[]>(ordersData);

//     const handleDrawerToggle = () => setMobileOpen(!mobileOpen);

//     // פונקציה פורמט תאריך ל-ISO YYYY-MM-DD (מתאימה להשוואה עם date במערך ההזמנות)
//     const formatDate = (date: Date) => date.toISOString().split('T')[0];

//     // סינון הזמנות לפי התאריך הנבחר
//     const filteredOrders = selectedDate
//         ? orders.filter((o) => o.date === formatDate(selectedDate))
//         : [];

//     // פונקציה לסימון הזמנה כהושלמה
//     const onComplete = (orderId: number) => {
//         setOrders((prev) =>
//             prev.map((order) =>
//                 order.id === orderId ? { ...order, completed: true } : order
//             )
//         );
//     };

//     // תכולת התפריט (הדרואר)
//     const drawer = (
//         <>
//             <Toolbar>
//                 <Typography
//                     variant="h6"
//                     noWrap
//                     component="div"
//                     sx={{ flexGrow: 1, color: 'white', textAlign: 'center' }}
//                 >
//                     דשבורד ניהול
//                 </Typography>
//             </Toolbar>
//             <Divider sx={{ bgcolor: 'white' }} />
//             <Box sx={{ p: 2 }}>
//                 <Calendar
//                     onClickDay={setSelectedDate}
//                     locale="he-IL"
//                     calendarType="hebrew"
//                     tileClassName={({ date }) => {
//                         const found = orders.find((o) => o.date === formatDate(date));
//                         return found ? 'highlighted-date' : '';
//                     }}
//                 />
//             </Box>
//         </>
//     );

//     return (
//         <Box sx={{ display: 'flex', direction: 'rtl' }}>
//             <CssBaseline />
//             <AppBar
//                 position="fixed"
//                 sx={{ zIndex: (theme) => theme.zIndex.drawer + 1, bgcolor: '#0097a7' }}
//             >
//                 <Toolbar>
//                     <IconButton
//                         color="inherit"
//                         edge="start"
//                         onClick={handleDrawerToggle}
//                         sx={{ mr: 2, display: { sm: 'none' } }}
//                         aria-label="open drawer"
//                     >
//                         <MenuIcon />
//                     </IconButton>
//                     <Typography variant="h6" noWrap component="div">
//                         דשבורד הזמנות {selectedDate ? `- ${selectedDate.toLocaleDateString('he-IL')}` : ''}
//                     </Typography>
//                 </Toolbar>
//             </AppBar>

//             {/* Drawer לצגים גדולים בלבד */}
//             <Drawer
//                 variant="permanent"
//                 sx={{
//                     width: drawerWidth,
//                     flexShrink: 0,
//                     [`& .MuiDrawer-paper`]: {
//                         width: drawerWidth,
//                         boxSizing: 'border-box',
//                         bgcolor: '#004d40',
//                         color: 'white',
//                     },
//                     display: { xs: 'none', sm: 'block' },
//                 }}
//                 open
//             >
//                 {drawer}
//             </Drawer>

//             {/* תוכן ראשי */}
//             <Box component="main" sx={{ flexGrow: 1, p: 3, mt: 8, overflowY: 'auto' }}>
//                 <Grid container spacing={3}>
//                     <Grid item xs={12} md={6} lg={7}>
//                         <Typography variant="h5" gutterBottom>
//                             הזמנות לתאריך {selectedDate ? selectedDate.toLocaleDateString('he-IL') : 'בחר תאריך'}
//                         </Typography>

//                         {selectedDate && filteredOrders.length === 0 && (
//                             <Typography variant="body1" color="text.secondary">
//                                 אין הזמנות לתאריך זה.
//                             </Typography>
//                         )}

//                         <Grid container spacing={2}>
//                             {filteredOrders.map((o) => (
//                                 <Grid item xs={12} key={o.id}>
//                                     <OrderCard order={o} onComplete={onComplete} />
//                                 </Grid>
//                             ))}
//                         </Grid>
//                     </Grid>

//                     <Grid item xs={12} md={6} lg={5}>
//                         <Paper elevation={8} sx={{ p: 2, borderRadius: 3, bgcolor: '#e0f7fa' }}>
//                             <Typography variant="h6" mb={2} textAlign="center">
//                                 סטטוס הזמנות יומי
//                             </Typography>
//                             <ResponsiveContainer width="100%" height={300}>
//                                 <BarChart
//                                     data={chartData}
//                                     margin={{ top: 20, right: 30, left: 0, bottom: 5 }}
//                                 >
//                                     <CartesianGrid strokeDasharray="3 3" />
//                                     <XAxis dataKey="name" />
//                                     <YAxis />
//                                     <Tooltip />
//                                     <Legend />
//                                     <Bar dataKey="completed" stackId="a" fill="#4caf50" />
//                                     <Bar dataKey="pending" stackId="a" fill="#ff9800" />
//                                 </BarChart>
//                             </ResponsiveContainer>
//                         </Paper>
//                     </Grid>
//                 </Grid>
//             </Box>

//             {/* סגנונות מיוחדים */}
//             <style>{`
//         .highlighted-date {
//           background: #0097a7 !important;
//           color: white !important;
//           border-radius: 50%;
//         }
//       `}</style>
//         </Box>
//     );
// }
