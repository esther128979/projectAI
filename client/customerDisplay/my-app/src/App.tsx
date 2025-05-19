
import './App.css';
import AppContent from './components/AppContent/AppContent';

import { useState } from 'react';
import { Routes, Route } from "react-router-dom";
import AdminLayout from "../src/components/AdminLayout/AdminLayout";
import { AdminScreen } from "../src/components/AdminScreen/AdminScreen";
import { OrderCardList } from "../src/components/OrderCardList/OrderCardList";
import { LogIn } from './components/LogIn/LogIn';
import { UserCardList } from './components/UserCardList/UserCardList';


export default function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isAdmin, setAdmin] = useState(true);

  function handleComplete(orderId: number) {
    console.log("סימנו כהושלם הזמנה מספר:", orderId);
    // כאן את יכולה לעדכן סטייט / לשלוח בקשה לשרת / להציג טוסטר
  }
return (
  <div className="row">
    <Routes>
      {isLoggedIn ? (
        isAdmin ? (
          <>
            {/* מסכים למנהל */}
            <Route path="/admin" element={<AdminLayout />}>
              <Route index element={<AdminScreen />} />
              <Route path="home" element={<AdminScreen />} />
              <Route path="customers" element={<UserCardList />} />
              <Route path="orders" element={<OrderCardList onComplete={handleComplete} />} />
            </Route>
          </>
        ) : (
          <>
            {/* מסכים ללקוח רגיל */}
            <Route path="/customer" element={<AdminLayout />}>
              <Route index element={<AppContent />} />
            </Route>
          </>
        )
      ) : (
        <>
          {/* מסך התחברות */}
          <Route path="/" element={<LogIn onLogin={() => setIsLoggedIn(true)} />} />
        </>
      )}
    </Routes>
  </div>
);

}
