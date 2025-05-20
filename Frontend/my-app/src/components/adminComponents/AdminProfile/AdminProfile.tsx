import React from 'react';
import './AdminProfile.scss';
import { LogOut, UserCircle } from 'lucide-react';

interface AdminProfileProps {
  name: string;
  email: string;
  onLogout: () => void;
}

export default function AdminProfile({ name, email, onLogout }: AdminProfileProps) {
  return (
    <div className="admin-profile gap-2">
      <UserCircle className="admin-icon" size={36} />
      <div className="admin-info">
        <div className="admin-name">{name}</div>
        <div className="admin-email">{email}</div>
      </div>
      <button className="logout-btn" onClick={onLogout}>
        <LogOut size={20} /> התנתקות
      </button>
    </div>
  );
}
