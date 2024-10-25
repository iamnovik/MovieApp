// ActorCredit.js
import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import config from '../config';
import '../styles/MovieCard.css'; 

const ActorCredit = ({ credit }) => {
    return (
        <div className="movie-card">
            <Link to={`/movie/${credit.id}`}>
                <img src={`${config.photoBaseUrl}${credit.poster_Path}`} alt={credit.title} />
                <h3 >{credit.title}</h3>
                
            </Link>

            <p >Character: {credit.character}</p>
        </div>
    );
};

// PropTypes for type checking
ActorCredit.propTypes = {
    credit: PropTypes.shape({
        id: PropTypes.number.isRequired,
        title: PropTypes.string.isRequired,
        character: PropTypes.string.isRequired,
    }).isRequired,
};

export default ActorCredit;
