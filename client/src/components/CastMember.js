// CastMember.js
import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import '../styles/CastMember.css'; 
import config from '../config';
const CastMember = ({ member }) => {
    const placeholderImage = '../assets/placeholder.jpg';
    return (
        <div className="cast-member">
            <Link to={`/actor/${member.id}`}>
                <img 
                    src={member.profile_Path !="null" ? `${config.photoBaseUrl}${member.profile_Path}` : placeholderImage} 
                    alt={`${member.name}'s profile`} 
                    className="cast-member-image" 
                />
                <div className="cast-member-details">
                    <h3 className="cast-member-name">{member.name}</h3>
                    <p className="cast-member-character">{member.character}</p>
                </div>
            </Link>
            
        </div>
    );
};

CastMember.propTypes = {
    member: PropTypes.shape({
        id: PropTypes.number.isRequired,
        name: PropTypes.string.isRequired,
        character: PropTypes.string.isRequired,
        profilePicture: PropTypes.string, 
    }).isRequired,
};

export default CastMember;
