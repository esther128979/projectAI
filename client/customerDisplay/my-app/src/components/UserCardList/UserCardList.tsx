// import React, { useState } from "react";
// import { Card, Avatar, Flex, Switch } from "antd";
// import {
//   EditOutlined,
//   EllipsisOutlined,
//   SettingOutlined,
// } from "@ant-design/icons";

// const { Meta } = Card;

// const CustomerList: React.FC = () => {
//   const [loading, setLoading] = useState(true);

//   const actions = [
//     <EditOutlined key="edit" />,
//     <SettingOutlined key="setting" />,
//     <EllipsisOutlined key="ellipsis" />,
//   ];

//   return (
//     <Flex gap="middle" align="start" vertical>
//       <Switch checked={!loading} onChange={(checked) => setLoading(!checked)} />

//       <Card loading={loading} actions={actions} style={{ minWidth: 300 }}>
//         <Meta
//           avatar={
//             <Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=1" />
//           }
//           title="Card title"
//           description={
//             <>
//               <p>This is the description</p>
//               <p>This is the description</p>
//             </>
//           }
//         />
//       </Card>

//       <Card loading={loading} actions={actions} style={{ minWidth: 300 }}>
//         <Meta
//           avatar={
//             <Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=2" />
//           }
//           title="Card title"
//           description={
//             <>
//               <p>This is the description</p>
//               <p>This is the description</p>
//             </>
//           }
//         />
//       </Card>
//     </Flex>
//   );
// };

// export default CustomerList;


//מקבל רשימה של משתמשים ויוצר רשימה של כרטיסים מהקומפוננטה כרטיס
import React from 'react';
import { UserProfileCard } from '../UserProfileCard/UserProfileCard';
import { User } from '../../models/User';


const moviesExemple: User[] = [
  {
    Id: 123,
    Name: 'Chaim',
    Phone: '0548523531',
    Email: 'leah23531@gmail.com'
  },
  {
    Id: 456,
    Name: 'Elisheva',
    Phone: '0548523531',
    Email: 'leah23531@gmail.com'
  },
  {
    Id: 789,
    Name: 'Tamar',
    Phone: '0548523531',
    Email: 'leah23531@gmail.com'
  }
]
const UserList = ({ users }: { users: User[] }) => {
  return (
    <div className="user-list">
      {users.map((user) => (
        <UserProfileCard key={user.Id} user={user} />
      ))}
    </div>
  );
};

export default UserList;
