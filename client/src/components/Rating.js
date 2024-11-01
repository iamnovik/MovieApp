import React from 'react';
import '../styles/Rating.css'; // Импортируйте ваш CSS файл

const Rating = ({ value }) => {
    // Количество звёзд
    const starCount = 5;
    // Вычисляем количество заполненных звёзд
    const filledStars = Math.round(value / 2); // 10 / 2 = 5 звёзд

    return (
        <div className="rating">
            {[...Array(starCount)].map((_, index) => {
                const starValue = index + 1;
                return (
                    <span key={starValue} className="star">
                        {starValue <= filledStars ? '★' : '☆'}
                    </span>
                );
            })}
        </div>
    );
};

export default Rating;
