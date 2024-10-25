import React, { useState} from 'react';
import Pagination from './Pagination'; 
import CastMember from './CastMember';
import "../styles/CastList.css"
const CastList = ({ cast }) => {
    const [currentPage, setCurrentPage] = useState(1);
    const actorsPerPage = 5;

    const totalPages = Math.ceil(cast.length / actorsPerPage);

    const displayedActors = cast.slice((currentPage - 1) * actorsPerPage, currentPage * actorsPerPage);

    return (
        <div>
             <div className="cast-list">
            {displayedActors.map(member => (
                <CastMember key={member.id} member={member} />
            ))}
            </div>
            <Pagination
                totalPages={totalPages}
                currentPage={currentPage}
                setPage={setCurrentPage} 
            />
        </div>
    );
};

export default CastList;
