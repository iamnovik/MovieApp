import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import Home from './pages/Home';
import MovieDetails from './pages/MovieDetails'
import ActorDetails from './pages/ActorDetails';
const App = () => {
    const [searchQuery, setSearchQuery] = useState('');
    return (
        <Router>
            <Header onSearch={setSearchQuery} />
            <Routes>
                <Route path="/" element={<Home query={searchQuery} />} />
                <Route path="/search" element={<Home query={searchQuery} />} />
                <Route path="/movie/:id" element={<MovieDetails />} />
                <Route path="/actor/:actorId" element={<ActorDetails />} />
            </Routes>
            <Footer />
        </Router>
    );
};

export default App;
