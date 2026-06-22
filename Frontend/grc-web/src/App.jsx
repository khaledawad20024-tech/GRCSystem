import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './store';

import Login from './Pages/Login';
import Dashboard from './Pages/Dashboardnew';
import ComplianceList from './Pages/Compliance/ComplianceList';
import ViolationsList from './Pages/Violations/ViolationsList';
import MinistersList from './Pages/Ministers/MinistersList';

import PrivateRoute from './components/PrivateRoute';
import Layout from './components/Layout';

function App() {
  return (
    <Provider store={store}>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />

          <Route
            path="/dashboard"
            element={
              <PrivateRoute>
                <Layout>
                  <Dashboard />
                </Layout>
              </PrivateRoute>
            }
          />

          <Route
            path="/compliance"
            element={
              <PrivateRoute>
                <Layout>
                  <ComplianceList />
                </Layout>
              </PrivateRoute>
            }
          />

          <Route
            path="/violations"
            element={
              <PrivateRoute>
                <Layout>
                  <ViolationsList />
                </Layout>
              </PrivateRoute>
            }
          />

          <Route
            path="/ministers"
            element={
              <PrivateRoute>
                <Layout>
                  <MinistersList />
                </Layout>
              </PrivateRoute>
            }
          />
        </Routes>
      </Router>
    </Provider>
  );
}

export default App;