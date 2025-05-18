import React from 'react';
import { Order } from '../../models/Order';
import { OrderCard } from '../OrderCard/OrderCard';
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
        }]
    }, {
      id: 1,
      date: '2025-05-13',
      completed: false,
      price: 89.9,
      movies: [
        {
          Id: 1,
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
          MovieName: "הטורף",
          MovieDescription: "סרט אקשן מותח על יצור חייזרי",
          MovieUrl: "https://example.com/the-predator",
          MoviePrice: 49.99
        }, {
          Id: 2,
          MovieName: "הארי פוטר ואבן החכמים",
          MovieDescription: "הסיפור הראשון בסדרת הסרטים המצליחה על הנער הקוסם",
          MovieUrl: "https://example.com/harry-potter",
          MoviePrice: 59.90
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
