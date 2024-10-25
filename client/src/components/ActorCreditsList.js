import React, {useState} from 'react';
import ActorCredit from './ActorCredit';
import "../styles/MovieList.css"
import Pagination from './Pagination';
const ActorCreditsList = ({ movies }) => {
    const [currentPage, setCurrentPage] = useState(1);
    const moviesPerPage = 5;

    const totalPages = Math.ceil(movies.length / moviesPerPage);

    const displayedMovies = movies.slice((currentPage - 1) * moviesPerPage, currentPage * moviesPerPage);
    return (
        <div>
            <div className="movie-list">
            {displayedMovies.map((movie) => (
                <ActorCredit credit={movie} />
            ))}
            </div>
            <Pagination totalPages={totalPages} currentPage={currentPage} setPage={setCurrentPage} />
        </div>
        
    );
};

export default ActorCreditsList;
