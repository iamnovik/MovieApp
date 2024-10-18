import React, { useEffect, useState } from 'react';
import axios from 'axios';
import MovieList from '../components/MovieList';
import API_BASE_URL from '../config'; 

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
                setTotalPages(response.data.total_pages);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        };

        fetchMovies();
    }, [page, query]);

    return (
        <div>
            <MovieList movies={movies} />
            <div className="pagination">
                {Array.from({ length: totalPages }, (_, index) => (
                    <button key={index + 1} onClick={() => setPage(index + 1)}>
                        {index + 1}
                    </button>
                ))}
            </div>
        </div>
    );
};

export default Home;
