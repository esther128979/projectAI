
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
  function handleComplete(orderId: number) {
    console.log("סימנו כהושלם הזמנה מספר:", orderId);
    // כאן את יכולה לעדכן סטייט / לשלוח בקשה לשרת / להציג טוסטר
  }
return(
    <div className='row'>
      {isLoggedIn ?
        (<Routes>
          {/* ביצוע בדיקה איזה מסך יוצג לו */}
          <Route path="/admin" element={<AdminLayout />}>
            <Route index element={<AdminScreen />} />
            <Route path="/admin/home" element={<AdminScreen />} />
            <Route path="/admin/customers" element={<UserCardList />} />
            <Route path="/admin/orders" element={<OrderCardList onComplete={handleComplete} />} />
            {/* <Route path="/admin/movies" element={ } /> */}
          </Route>

          <Route path="/customer" element={<AdminLayout />}>
             <AppContent />
          </Route>

        </Routes>) :
        (<Routes>
          <Route path="/" element={<LogIn onLogin={() => setIsLoggedIn(true)} />} />
          </Routes>
        )}
    </div>
  );
}
