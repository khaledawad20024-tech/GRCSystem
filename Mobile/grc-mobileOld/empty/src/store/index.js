import { configureStore } from '@reduxjs/toolkit';
import authReducer from './slices/authSlice';

const store = configureStore({
  reducer: {
    auth: authReducer
  }
});

console.log("STORE TYPE:", typeof store);
console.log("STORE:", store);

export default store;