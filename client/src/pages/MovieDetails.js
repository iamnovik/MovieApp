import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import CastList from '../components/CastList'; 
import Rating from '../components/Rating';
import config from '../config'; 
import "../styles/MovieDetails.css"
const MovieDetails = () => {
    
    const { id } = useParams(); 
    const [movie, setMovie] = useState(null);
    const [cast, setCast] = useState([]); 
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const fetchMovieDetails = async () => {
        try {
            const response = await fetch(`${config.apiBaseUrl}/movie/${id}`);
            const data = await response.json();
            console.log(data)
            setMovie(data);
        } catch (error) {
            console.error("Error fetching movie details:", error);
        }
    };

    const fetchCast = async () => {
        try {
            const response = await fetch(`${config.apiBaseUrl}/actors/movie/${id}`); 
            const data = await response.json();
            console.log(data)
            setCast(data);
        } catch (error) {
            console.error("Error fetching cast:", error);
        }
    };

    useEffect(() => {
        fetchMovieDetails();
        fetchCast();
    }, [id]);

    if (!movie) return <div>Loading...</div>;

    return (
        <div 
            className="movie-details" 
            style={{ backgroundImage: `url(${config.photoBaseUrl}${movie.poster_Path})` }}
        >
            <div className="details-container">
                <img 
                    className="movie-poster" 
                    src={`${config.photoBaseUrl}${movie.poster_Path}`} 
                    alt={movie.title} 
                />
                <div className="movie-info">
                    <h1>{movie.title}</h1>
                    <p><strong>{movie.overview}</strong> </p>
                    <div>
                        <strong>Rating:</strong>
                        <Rating value={movie.vote_Average} />
                        <span>{movie.vote_Average} ({movie.vote_Count} votes)</span>
                    </div>
                    <p><strong>Release Date:</strong> {new Date(movie.release_Date).toLocaleDateString('en-US', options)}</p>

                    <h2>Cast</h2>
                    <CastList cast={cast} />
                </div>
            </div>
        </div>
    );
};

export default MovieDetails;
