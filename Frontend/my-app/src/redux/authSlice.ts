import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../myStore'; // ודאי שהנתיב נכון

type Role = 'admin' | 'user' | null;

interface AuthState {
  isLoggedIn: boolean;
  role: Role;
  username: string | null;
  token: string | null; // 👈 הוספנו את זה
}

const initialState: AuthState = {
  isLoggedIn: false,
  role: null,
  username: null,
  token: null, // 👈 הוספנו את זה
};

export const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    loginUser: (state, action: PayloadAction<{ role: Role; username: string; token: string }>) => {
      state.isLoggedIn = true;
      state.role = action.payload.role;
      state.username = action.payload.username;
      state.token = action.payload.token; // 👈 שמירה של הטוקן
    },
    logout(state) {
      state.isLoggedIn = false;
      state.role = null;
      state.username = null;
      state.token = null; // 👈 איפוס הטוקן בעת התנתקות
    },
  },
});

export const { loginUser, logout } = authSlice.actions;
export default authSlice.reducer;
export const selectUsername=(state:RootState)=>state.auth.username;
