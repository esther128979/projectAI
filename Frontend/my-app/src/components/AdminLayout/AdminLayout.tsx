import { Outlet, useNavigate } from "react-router-dom";
import AdminNav from "../AdminNav/AdminNav";
import AdminProfile from "../AdminProfile/AdminProfile";

export default function AdminLayout() {
  const navigate = useNavigate();
  return (
    <div>
      <AdminNav />
      <AdminProfile
        name="רפאל קליפשטיין"
        email="admin@dosflix.co.il"
        onLogout={() => navigate("/")}/>
      <Outlet />
    </div>
  );
}
