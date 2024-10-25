import React, { useEffect, useState } from 'react';
import axios from 'axios';
import MovieList from '../components/MovieList';
import API_BASE_URL from '../config'; 
import Pagination from '../components/Pagination';
const Home = ({ query }) => {
    const [movies, setMovies] = useState([]);
    const [page, setPage] = useState(1);
    const [totalPages, setTotalPages] = useState(0);
    useEffect(() => {
        const fetchMovies = async () => {
            try {
                const endpoint = query
                    ? `${API_BASE_URL}/movie/search?query=${query}&page=${page}`
                    : `${API_BASE_URL}/movie/?page=${page}`;

                const response = await axios.get(endpoint);
                setMovies(response.data.results);
                setTotalPages(response.data.total_Pages);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchMovies();
    }, [page, query]);

    return (
        <div >
            <MovieList movies={movies} />
            <Pagination totalPages={totalPages} currentPage={page} setPage={setPage} />
        </div>
    );
};

export default Home;
