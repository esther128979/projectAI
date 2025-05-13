// // import { Link } from 'react-router-dom';
// // import './AdminNav.scss';

// // export default function AdminNav() {
// //   return (
// //     <nav className="navbar navbar-expand-lg custom-navbar">
// //       <div className="container-fluid">
// //         <span className="navbar-brand text-white">ניהול מערכת</span>
// //         <ul className="navbar-nav me-auto mb-2 mb-lg-0">
// //           <li className="nav-item">
// //             <Link className="nav-link text-white" to="/admin/clients">לקוחות</Link>
// //           </li>
// //           <li className="nav-item">
// //             <Link className="nav-link text-white" to="/admin/orders">הזמנות</Link>
// //           </li>
// //           <li className="nav-item">
// //             <Link className="nav-link text-white" to="/admin/movies">סרטים</Link>
// //           </li>
// //         </ul>
// //       </div>
// //     </nav>
// //   );
// // }
// import { Link } from 'react-router-dom';
// import './AdminNav.scss';

// export default function AdminNav() {
//   return (
//     <nav className="navbar custom-navbar fixed-top">
//       <div className="container-fluid d-flex justify-content-center">
//         <ul className="nav nav-pills">
//           <li className="nav-item">
//             <Link className="nav-link nav-square" to="/admin/clients">לקוחות</Link>
//           </li>
//           <li className="nav-item">
//             <Link className="nav-link nav-square" to="/admin/orders">הזמנות</Link>
//           </li>
//           <li className="nav-item">
//             <Link className="nav-link nav-square" to="/admin/movies">סרטים</Link>
//           </li>
//         </ul>
//       </div>
//     </nav>
//   );
// }
import { Link } from 'react-router-dom';
import './AdminNav.scss';

export default function AdminNav() {
  return (
    <nav className="navbar custom-navbar fixed-top">
      <div className="container-fluid d-flex justify-content-between align-items-center">

        {/* כפתור דף ראשי
        <Link to="/admin" className="nav-link nav-square home-button">
          דף ניהול
        </Link> */}
        <Link className="nav-link simple-link" to="/admin">דף ניהול</Link>

        {/* תפריט ניווט */}
        <ul className="nav nav-pills m-0">
          <li className="nav-item">
            <Link className="nav-link nav-square" to="/admin/clients">לקוחות</Link>
          </li>
          <li className="nav-item">
            <Link className="nav-link nav-square" to="/admin/orders">הזמנות</Link>
          </li>
          <li className="nav-item">
            <Link className="nav-link nav-square" to="/admin/movies">סרטים</Link>
          </li>
        </ul>
      </div>
    </nav>
  );
}
