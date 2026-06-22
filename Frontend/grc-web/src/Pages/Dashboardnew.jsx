// src/pages/Dashboard.jsx
import React, { useEffect, useState } from 'react';
import {
  Grid,
  Card,
  CardContent,
  Typography,
  Box,
  CircularProgress
} from '@mui/material';

import {
  LineChart,
  Line,
  BarChart,
  Bar,
  PieChart,
  Pie,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend,
  ResponsiveContainer
} from 'recharts';

import api from '../services/api';

const Dashboard = () => {
  const [kpis, setKpis] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchKPIs();
  }, []);

  const fetchKPIs = async () => {
    try {
      const response = await api.get('/api/dashboard/kpis');
      setKpis(response.data);
      setLoading(false);
    } catch (error) {
      console.error('Error fetching KPIs:', error);
      setLoading(false);
    }
  };

  if (loading) return <CircularProgress />;

  return (
    <Box sx={{ p: 3 }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        لوحة التحكم
      </Typography>

      <Grid container spacing={3}>
        {/* Compliance Articles KPI */}
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent>
              <Typography color="textSecondary" gutterBottom>
                مواد الالتزام
              </Typography>
              <Typography variant="h5">
                {kpis?.complianceArticlesCount || 0}
              </Typography>
            </CardContent>
          </Card>
        </Grid>

        {/* Violations KPI */}
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent>
              <Typography color="textSecondary" gutterBottom>
                المخالفات
              </Typography>
              <Typography variant="h5">
                {kpis?.violationsCount || 0}
              </Typography>
            </CardContent>
          </Card>
        </Grid>

        {/* Total Fines KPI */}
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent>
              <Typography color="textSecondary" gutterBottom>
                إجمالي الغرامات
              </Typography>
              <Typography variant="h5">
                {kpis?.totalFines?.toLocaleString()} د.ك
              </Typography>
            </CardContent>
          </Card>
        </Grid>

        {/* Ministers KPI */}
        <Grid item xs={12} sm={6} md={3}>
          <Card>
            <CardContent>
              <Typography color="textSecondary" gutterBottom>
                الوزراء
              </Typography>
              <Typography variant="h5">
                {kpis?.ministersCount || 0}
              </Typography>
            </CardContent>
          </Card>
        </Grid>

        {/* Chart */}
        <Grid item xs={12}>
          <Card>
            <CardContent>
              <Typography variant="h6" sx={{ mb: 2 }}>
                إحصائيات المخالفات
              </Typography>
              <ResponsiveContainer width="100%" height={300}>
                <LineChart data={kpis?.chartData || []}>
                  <CartesianGrid strokeDasharray="3 3" />
                  <XAxis dataKey="name" />
                  <YAxis />
                  <Tooltip />
                  <Legend />
                  <Line type="monotone" dataKey="violations" stroke="#8884d8" />
                  <Line type="monotone" dataKey="fines" stroke="#82ca9d" />
                </LineChart>
              </ResponsiveContainer>
            </CardContent>
          </Card>
        </Grid>
      </Grid>
    </Box>
  );
};

export default Dashboard;