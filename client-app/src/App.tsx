import React from 'react';
import Header from './app/components/Header';
import HomePage from './app/pages/HomePage';
import { Route } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Header />
      <Route exact path="/" component={HomePage} />
    </div>
  );
}

export default App;
