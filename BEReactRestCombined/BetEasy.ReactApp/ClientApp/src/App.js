import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import NextToJump from './components/NextToJump';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
        <Route path='/nexttojump' component={NextToJump} />
  </Layout>
);
