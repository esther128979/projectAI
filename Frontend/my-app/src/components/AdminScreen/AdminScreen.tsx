import './AdminScreen.scss';
import { } from '@mui/icons-material';
import { User, Gender } from '../../models/User'
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Order } from '@/models/Order';
import { MovieObject } from '@/models/Movie';
import { OrderCardList } from '../OrderCardList/OrderCardList';
import SearchBar from '../SearchBar/SearchBar';

export function AdminScreen() {
  const [searchTerm, setSearchTerm] = useState('');
  const navigate = useNavigate();

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

  const orderArr: Order[] = [
    {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
    , {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          Name: "הטורף",
          Description: "סרט אקשן מותח על יצור חייזרי",
          Url: "https://example.com/the-predator",
          Price: 49.99
        }, {
          Id: 2,
          Name: "הארי פוטר ואבן החכמים",
          Description: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          Url: "https://example.com/harry-potter",
          Price: 59.90
        }]
    }
  ]

  //פונקצית סינון חכמה
  const filteredUsers = arrUser.filter((user) =>
    Object.values(user).some((value) =>
      value.toString().toLowerCase().includes(searchTerm.toLowerCase())
    )
  );

  const handleComplete = (orderId: number) => {
    console.log(`ההזמנה עם מזהה ${orderId} סומנה כהושלמה`);
    // פה תעשי setState או קריאת API לפי הצורך
  };

  return (
    <>
      <div className='cardList'>
        {/* פונקציה זמנית */}
       {/* <SearchBar onSearch={(query) => console.log("חיפוש:", query)} /> */}
        {/* קריאה לכל ההזמנות שהסטטוס שלהן לא טופל */}
        <OrderCardList onComplete={handleComplete}></OrderCardList>
      </div>
    </>
  );
}

