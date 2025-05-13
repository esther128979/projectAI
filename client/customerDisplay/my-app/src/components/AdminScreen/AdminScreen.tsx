
import './AdminScreen.scss';
import  AdminNav from '../AdminNav/AdminNav';
import UserCardList from '../UserCardList/UserCardList';
import { } from '@mui/icons-material';
import { User,Gender } from '../../models/User'
import { useState } from 'react';
import SearchBar from '../SearchBar/SearchBar';
// export function AdminScreen() {
//   const arrUser = [
//     {
//       Name: 'Moshe',
//       Phone: '0524875898',
//       Email: 'm@gmail.com',
//       Id: 4525,
//       Address: 'Geffen 23 street',
//       Gender:Gender.male
//   },
//     {
//       Name: 'David',
//       Phone: '0589656632',
//       Email: 'd@gmail.com',
//       Id: 8785,
//       Address: 'Duvdevan 6 street',
//       Gender:Gender.male
//     },
//   ];
//   return (
//     <div>
//       <AdminNav></AdminNav>
//       פונקציה שמביאה מהשרת את כל הלקוחות שהזמנתם לא טופלה
//       <UserCardList users={arrUser}></UserCardList>
//     </div>
//     // <h1>זה מסך מנהל</h1>

//   )
// }
export function AdminScreen() {
  const [searchTerm, setSearchTerm] = useState('');

  const arrUser: User[] = [
    {
      Name: 'Moshe',
      Phone: '0524875898',
      Email: 'm@gmail.com',
      Id: 4525,
      Address: 'Geffen 23 street',
      Gender: Gender.male,
    },
    {
      Name: 'David',
      Phone: '0589656632',
      Email: 'd@gmail.com',
      Id: 8785,
      Address: 'Duvdevan 6 street',
      Gender: Gender.male,
    },
  ];

  // פונקציית סינון חכמה
  const filteredUsers = arrUser.filter((user) =>
    Object.values(user).some((value) =>
      value.toString().toLowerCase().includes(searchTerm.toLowerCase())
    )
  );

  return (
    <div>
      <AdminNav />
      <SearchBar onSearch={setSearchTerm} />
      <p>פונקציה שמביאה מהשרת את כל הלקוחות שהזמנתם לא טופלה</p>
      <UserCardList users={filteredUsers} />
    </div>
  );
}