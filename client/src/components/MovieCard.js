import React from 'react';
import "../styles/MovieCard.css"
import { Link } from 'react-router-dom';
import config from '../config';
import Rating from './Rating';
import '../styles/Rating.css'

const MovieCard = ({ movie }) => {


    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    return (
        <div className="movie-card">
            <Link to={`/movie/${movie.id}`}>
                <img src={`${config.photoBaseUrl}${movie.poster_Path}`} alt={movie.title} />
                <h3>{movie.title}</h3>
            </Link>
            <p>Release Date: { new Date(movie.release_Date).toLocaleDateString('en-US', options)}</p>
            <p style={{justifyContent : "center"}}> 
                        <strong>Rating:</strong>
                        <Rating value={movie.vote_Average} />
                        <span>{movie.vote_Average} ({movie.vote_Count} votes)</span>
                    </p>
        </div>
    );
};

export default MovieCard;
