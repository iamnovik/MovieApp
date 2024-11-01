import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import "../styles/Header.css"
const Header = ({ onSearch }) => {
    const [query, setQuery] = useState('');
    const navigate = useNavigate();

    const handleSearch = (e) => {
        e.preventDefault();
        if (query) {
            navigate(`/search?query=${query}`);
            onSearch(query);
        }
    };

    const handleHomeClick = () => {
        setQuery(''); 
        onSearch(''); 
    };

    return (
        <header className="header">
            <Link to="/" onClick={handleHomeClick} className="header-title">
                <h1>Movie App</h1>
            </Link>
            <form onSubmit={handleSearch} className="header-search-form">
                <input
                    type="text"
                    value={query}
                    onChange={(e) => setQuery(e.target.value)}
                    placeholder="Search for movies..."
                />
                <button type="submit" className="header-search-button">Search</button>
            </form>
        </header>
    );
};

export default Header;
