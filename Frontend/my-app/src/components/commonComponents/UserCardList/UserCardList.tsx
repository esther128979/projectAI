
import React, { useState } from "react";
import { Box } from "@mui/material";
import { UserCard } from "../UserCard/UserCard";
import { Order } from "../../../models/Order";
import { User, Gender } from '../../../models/User';
import './UserCardList.scss';
const users: User[] = [
  {
    Name: "חיים",
    Phone: "050-1234567",
    Email: "chaim@gmail.com",
    Id: 1,
    Address: "רחוב הדוגמה 5",
    Gender: Gender.male
  },
  {
    Name: "לאה",
    Phone: "050-1234567",
    Email: "lea@gmail.com",
    Id: 2,
    Address: "רחוב הדוגמה 5",
    Gender: Gender.female
  }
];

const orders: Order[] = [
  {
    id: 1,
    date: "2025-05-01",
    movies: [
      { Id: 101, Name: "סרט א" },
      { Id: 102, Name: "סרט ב" },
    ],
    price: 75,
    completed: true,
  },
  {
    id: 2,
    date: "2025-04-20",
    movies: [
      { Id: 103, Name: "סרט ג" },
    ],
    price: 30,
    completed: false,
  },
];

export function UserCardList() {
  const [selectedOrders, setSelectedOrders] = useState<Order[] | null>(null);
  const [isModalOpen, setIsModalOpen] = useState(false);

  // פונקציה לדוגמה שמחזירה הזמנות - כאן אפשר להוסיף קריאה אמיתית בעתיד
  const handleGetOrders = async (userId: number): Promise<Order[]> => {
    // לדוגמה, כרגע מחזירים הזמנות מדומות
    setSelectedOrders(orders);
    setIsModalOpen(true);
    return orders;
  };

  return (
    <>
    <div className="listUsers">
      <Box 
        sx={{ 
          display: "flex", 
          flexDirection: "row", 
          flexWrap: "wrap",     
          justifyContent: "center",
          gap: 3,               
          padding: 2
        }}
      >
        {users.map((user) => (
          <UserCard key={user.Id} user={user} getOrders={handleGetOrders} />
        ))}
      </Box>
      </div>
    </>
  );
}
