import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../myStore'; // ודאי שהנתיב נכון

type Role = 'admin' | 'user' | null;

interface AuthState {
  isLoggedIn: boolean;
  role: Role;
  username: string | null;
}

const initialState: AuthState = {
  isLoggedIn: false,
  role: null,
  username: null,
};

export const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    loginUser:(state, action: PayloadAction<{ role: Role; username: string }>) =>{
      debugger
      state.isLoggedIn = true;
      state.role = action.payload.role;
      state.username = action.payload.username;
    },
    logout(state) {
      state.isLoggedIn = false;
      state.role = null;
      state.username = null;
    },
  },
});

export const { loginUser, logout } = authSlice.actions;
export default authSlice.reducer;
export const selectUsername = (state: RootState) => state.auth.username;
