import { useState } from 'react';
import { Grid, Paper, Typography, Box } from '@mui/material';
import DashboardCard from '../DashboardCard/DashboardCard';
import SalesChart from '../SalesChart/SalesChart';
import TaskList from '../TaskList/TaskList';
import Calendar from '../Calendar/Calendar';
import ChatBox from '../ChatBox/ChatBox';
import TopMoviesChart from '../TopMoviesChart/TopMoviesChart';
import ChatWidget from '../ChatWidget/ChatWidget';

export const Dashboard = () => {
  const [chatActive, setChatActive] = useState(false);

  return (
    <Box sx={{ p: 3, mt: 8, position:'absolute', marginTop:0}}>
      <Grid container spacing={3}>
        {/* כרטיסי סטטיסטיקה (אם זה Grid item בפנים) */}
        <DashboardCard />

        {/* גרף מכירות + לוח שנה */}
        <Grid item xs={12} md={9}>
          <Paper elevation={3} sx={{ p: 2, borderRadius: 2, height: 250 }}>

            <Box sx={{ height: 'calc(100% - 32px)' }}>
              <SalesChart />
            </Box>
          </Paper>
        </Grid>

        <Grid item xs={12} md={3}>
          <Paper elevation={3} sx={{ p: 2, borderRadius: 2, height: 250 }}>
            <Box sx={{ height: 'calc(100% - 32px)' }}>
              <TopMoviesChart />
            </Box>
          </Paper>
        </Grid>

        <Grid item xs={12} md={5}>
          <Paper elevation={3} sx={{ p: 2, borderRadius: 2, height: 350, overflow: 'auto' }}>
            <TaskList />
          </Paper>
        </Grid>
        <Grid item xs={12} md={4}>
          <Paper elevation={3} sx={{ p: 2, borderRadius: 2, height: 350 }}>
            <Box sx={{ height: 'calc(100% - 32px)' }}>
              <Calendar />
            </Box>
          </Paper>
        </Grid>
        <Grid item xs={12} md={3}>
          {chatActive?
        ( <Paper elevation={3} sx={{ p: 2, borderRadius: 2, height: 350, overflow: "auto" }}>
            <ChatWidget chatActive={chatActive} setChatActive={setChatActive} />
          </Paper>):(
            <ChatWidget chatActive={chatActive} setChatActive={setChatActive} />
         )}
        </Grid>
      </Grid>
    </Box>
  );
};
