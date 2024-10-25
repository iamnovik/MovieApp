import React from 'react';
import '../styles/Pagination.css'
const Pagination = ({ totalPages, currentPage, setPage }) => {
    const getDisplayedPages = () => {
        const startPage = Math.max(currentPage - 2, 1);
        const endPage = Math.min(currentPage + 2, totalPages);

        return Array.from({ length: endPage - startPage + 1 }, (_, i) => startPage + i);
    };

    return (
        <div className="pagination">
            <button
                onClick={() => setPage(Math.max(currentPage - 1, 1))}
                disabled={currentPage === 1}
            >
                &lt;
            </button>

            {getDisplayedPages().map((page) => (
                <button
                    key={page}
                    onClick={() => setPage(page)}
                    className={page === currentPage ? 'active' : ''}
                >
                    {page}
                </button>
            ))}

            <button
                onClick={() => setPage(Math.min(currentPage + 1, totalPages))}
                disabled={currentPage === totalPages}
            >
                &gt;
            </button>
        </div>
    );
};

export default Pagination;
