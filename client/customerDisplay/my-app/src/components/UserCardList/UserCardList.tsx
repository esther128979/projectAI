// import React from 'react';
// import { UserProfileCard } from '../UserProfileCard/UserProfileCard';
// import { User } from '../../models/User';

// interface UserListProps {
//   users: User[];
//   onShowOrders?: (userId: number) => void;
// }

// const UserList = ({ users, onShowOrders }: UserListProps) => {
//   return (
//     <div className="flex flex-col items-center gap-4 p-4">
//       {users.map((user) => (
//         <UserProfileCard
//           key={user.Id}
//           user={user}
//           onShowOrders={onShowOrders}
//         />
//       ))}
//     </div>
//   );
// };

// export default UserList;
import React, { useState } from 'react';
import { UserProfileCard } from '../UserProfileCard/UserProfileCard';
import { User } from '../../models/User';
import OrdersModal from '../OrdersModal/OrdersModal';
import { Order } from '../../models/Order';

interface UserListProps {
  users: User[];
}

const fetchOrdersForUser = async (userId: number): Promise<Order[]> => {
  // כאן אפשר להחליף לקריאת fetch אמיתית בעתיד
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

const UserList = ({ users }: UserListProps) => {
  const [selectedOrders, setSelectedOrders] = useState<Order[] | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);

  const handleShowOrders = async (userId: number) => {
    const orders = await fetchOrdersForUser(userId);
    setSelectedOrders(orders);
    setIsModalOpen(true);
  };

  return (
    <div className="flex flex-col items-center gap-4 p-4">
      {users.map((user) => (
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
};

export default UserList;
