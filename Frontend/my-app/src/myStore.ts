import { configureStore } from '@reduxjs/toolkit';
import authReducer from './redux/authSlice'; // תוודאי שזה הנתיב הנכון אל הקובץ שלך

// יצירת ה-store הכללי
export const myStore = configureStore({
  reducer: {
    auth: authReducer,
  },
});

// טיפוסים בשביל TypeScript
export type RootState = ReturnType<typeof myStore.getState>;
export type AppDispatch = typeof myStore.dispatch;
