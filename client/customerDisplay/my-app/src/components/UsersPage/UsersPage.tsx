import OrdersModal from "../OrdersModal/OrdersModal";
import { UserProfileCard } from "../UserProfileCard/UserProfileCard";
import { useState } from "react";
import { Order } from "../../models/Order"; // שימי לב לנתיב בהתאם למבנה התיקיות שלך
import { User } from "../../models/User"; // שימי לב לנתיב בהתאם למבנה התיקיות שלך

const fetchOrdersForUser = async (userId: number): Promise<Order[]> => {
//   const response = await fetch(`/api/orders/${userId}`);
//   const data = await response.json();
//   return data;
 return [
    {
      id: 1,
      date: '2025-05-01',
      movies: ['סרט א', 'סרט ב'],
      price: 75,
      paid: true,
    },
    {
      id: 2,
      date: '2025-04-20',
      movies: ['סרט ג'],
      price: 30,
      paid: false,
    },
  ];
};
interface Props {
  users: User[];
}
export function UsersPage({ users }: Props) {
  const [selectedOrders, setSelectedOrders] = useState<Order[] | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const handleShowOrders = async (userId: number) => {
    const orders = await fetchOrdersForUser(userId); // קריאה לפונקציה שמביאה את ההזמנות
    setSelectedOrders(orders);
    setIsModalOpen(true);
  };

  return (
    <div className="grid grid-cols-3 gap-4">
      {users.map(user => (
        <UserProfileCard
          key={user.Id}
          user={user}
          onShowOrders={handleShowOrders}
        />
      ))}

      <OrdersModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        orders={selectedOrders || []}
      />
    </div>
  );
}
