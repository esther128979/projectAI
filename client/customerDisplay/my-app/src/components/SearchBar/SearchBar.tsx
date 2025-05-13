// import React, { useState } from 'react';
// import  './SearchBar.scss';
// interface SearchBarProps {
//     onSearch: (value: string) => void;
//   }
// const SearchBar = ({ onSearch }:SearchBarProps) => {
//   const [query, setQuery] = useState('');

//   const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
//     const value = e.target.value;
//     setQuery(value);
//     onSearch(value); // שולחת את ערך החיפוש החוצה
//   };

//   return (
//     <div className="mb-3 text-center">
//       <input
//         type="text"
//         className="form-control"
//         placeholder="חפש לפי שם, מייל, סרט..."
//         value={query}
//         onChange={handleChange}
//         style={{ maxWidth: '400px', margin: '0 auto' }}
//       />
//     </div>
//   );
// };

// export default SearchBar;
import React, { ChangeEvent } from 'react';

interface SearchBarProps {
  onSearch: (query: string) => void;
}

export default function SearchBar({ onSearch }: SearchBarProps) {
  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    onSearch(e.target.value);
  };

  return (
    <input
      type="text"
      className="form-control mb-3"
      placeholder="חפש סרטים, משתמשים או הזמנות..."
      onChange={handleChange}
    />
  );
}
