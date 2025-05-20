import { Link } from 'react-router-dom';
import './AdminNav.scss';

export default function AdminNav() {
  return (
    <nav className="custom-navbar-vertical">
      <ul className="nav nav-pills">
        <li className="nav-item">
          <Link className="nav-link nav-square" to="/admin/home">ראשי</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link nav-square" to="/admin/customers">לקוחות</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link nav-square" to="/admin/orders">הזמנות</Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link nav-square" to="/admin/movies">סרטים</Link>
        </li>
      </ul>
    </nav>
  );
}
