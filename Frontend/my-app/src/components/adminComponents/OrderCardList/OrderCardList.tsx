import React from 'react';
import { Order } from '../../../models/Order';
import { OrderCard } from '../OrderCard/OrderCard'
import './OrderCardList.scss';

interface OrderCardListProps {
  onComplete: (orderId: number) => void;
}

export function OrderCardList({ onComplete }: OrderCardListProps) {
 const orders: Order[] = [
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

  if (orders.length === 0) {
    return (
      <div className="text-center text-gray-500 mt-8 text-lg">
        לא נמצאו הזמנות. 
      </div>
    );
  }

  return (
    <>
  <div className="scroll-container">
    <div className="cards-grid">
      {orders.map(order => (
        <OrderCard key={order.id} order={order} onComplete={onComplete} />
      ))}
    </div>
  </div>
  </>
);}
