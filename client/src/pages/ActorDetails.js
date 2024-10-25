import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import config from '../config'; 
import '../styles/ActorDetails.css'; 
import ActorCreditsList from '../components/ActorCreditsList';
import Rating from '../components/Rating';
const ActorDetails = () => {
    const { actorId } = useParams();
    const [actor, setActor] = useState(null);
    const [credits, setCredits] = useState([]);
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const placeholderImage = '../assets/placeholder.jpg';
    const fetchActorDetails = async () => {
        try {
            const response = await fetch(`${config.apiBaseUrl}/actors/${actorId}`);
            const data = await response.json();
            console.log(data)
            setActor(data);
        } catch (error) {
            console.error('Ошибка при получении данных об актёре:', error);
        }
    };

    const fetchActorCredits = async () => {
        try {
            const response = await fetch(`${config.apiBaseUrl}/actors/${actorId}/combined_credits`);
            const data = await response.json();
            console.log(data)
            setCredits(data);
        } catch (error) {
            console.error('Ошибка при получении данных о кредитах:', error);
        }
    };

    useEffect(() => {
        fetchActorDetails();
        fetchActorCredits();
    }, [actorId]);

    if (!actor) {
        return <div>Загрузка...</div>;
    }

    return (
        <div className="actor-details">
            <div className="actor-profile">
                <img 
                    src={actor.profile_Path ? `${config.photoBaseUrl}${actor.profile_Path}` : placeholderImage} 
                    alt={actor.name} 
                />
                <h1>{actor.name}</h1>
                
            </div>
            <p><strong>Birthdate:</strong> {new Date(actor.birthday).toLocaleDateString('en-US', options)}</p>
                <p><strong>Biography:</strong> {actor.biography}</p>
                <p>
                    <strong>Popularity:</strong>
                    <Rating value={actor.popularity} />
                </p>
                <p><strong>Also known as:</strong> {actor.also_Known_As.join(', ')}</p>
            <h2>Films with the actor's participation:</h2>
            <ActorCreditsList movies={credits} />
        </div>
    );
};

export default ActorDetails;
