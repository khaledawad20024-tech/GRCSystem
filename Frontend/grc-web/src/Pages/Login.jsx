import React, { useState } from 'react';
import {
  Container,
  Paper,
  TextField,
  Button,
  Box,
  Typography,
  Alert
} from '@mui/material';

import { useNavigate } from 'react-router-dom';
import { useDispatch } from 'react-redux';

import api from '../services/api';
import { setUser, setToken } from '../store/slices/authSlice';

const Login = () => {
  const [username, setUsernameValue] = useState('');
  const [password, setPasswordValue] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const navigate = useNavigate();
  const dispatch = useDispatch();

  const handleLogin = async (e) => {
    e.preventDefault();

    setLoading(true);
    setError('');

    try {
      const response = await api.post('/api/auth/login', {
        username,
        password
      });

      dispatch(setToken(response.data.accessToken));
      dispatch(setUser(response.data.user));

      localStorage.setItem(
        'token',
        response.data.accessToken
      );

      localStorage.setItem(
        'refreshToken',
        response.data.refreshToken
      );

      navigate('/dashboard');
    } catch (err) {
      setError('فشل تسجيل الدخول');
    } finally {
      setLoading(false);
    }
  };

  return (
    <Container maxWidth="sm">
      <Box
        sx={{
          minHeight: '100vh',
          display: 'flex',
          alignItems: 'center'
        }}
      >
        <Paper sx={{ p: 4, width: '100%' }}>
          <Typography
            variant="h4"
            align="center"
            sx={{ mb: 3 }}
          >
            نظام الحوكمة والامتثال
          </Typography>

          {error && (
            <Alert severity="error">
              {error}
            </Alert>
          )}

          <Box
            component="form"
            onSubmit={handleLogin}
          >
            <TextField
              fullWidth
              label="اسم المستخدم"
              margin="normal"
              value={username}
              onChange={(e) =>
                setUsernameValue(e.target.value)
              }
            />

            <TextField
              fullWidth
              type="password"
              label="كلمة المرور"
              margin="normal"
              value={password}
              onChange={(e) =>
                setPasswordValue(e.target.value)
              }
            />

            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 2 }}
              disabled={loading}
            >
              {loading
                ? 'جاري تسجيل الدخول...'
                : 'دخول'}
            </Button>
          </Box>
        </Paper>
      </Box>
    </Container>
  );
};

export default Login;