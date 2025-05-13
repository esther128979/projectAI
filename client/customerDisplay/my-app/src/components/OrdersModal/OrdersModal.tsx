// components/OrdersModal.tsx
import { DialogPanel,Dialog,DialogTitle } from '@headlessui/react';
import { XMarkIcon } from '@heroicons/react/24/outline';
import { Order } from "../../models/Order";

// type Order = {
//   id: number;
//   date: string;
//   movies: string[];
//   price: number;
//   completed: boolean;
// };

interface OrdersModalProps {
  isOpen: boolean;
  onClose: () => void;
  orders: Order[];
}
export default function OrdersModal({ isOpen, onClose, orders }:OrdersModalProps) {
  return (
    <Dialog open={isOpen} onClose={onClose} className="relative z-50">
      <div className="fixed inset-0 bg-black/30" aria-hidden="true" />
      <div className="fixed inset-0 flex items-center justify-center p-4">
        <DialogPanel className="w-full max-w-2xl bg-white rounded-lg p-6 shadow-xl relative">
          <button
            onClick={onClose}
            className="absolute top-3 left-3 text-gray-500 hover:text-black"
          >
            <XMarkIcon className="w-6 h-6" />
          </button>

          <DialogTitle className="text-xl font-bold mb-4 text-center">
            הזמנות מהשנה האחרונה
          </DialogTitle>

          <table className="w-full border text-right text-sm">
            <thead>
              <tr className="bg-gray-100">
                <th className="border px-2 py-1">תאריך</th>
                <th className="border px-2 py-1">סרטים</th>
                <th className="border px-2 py-1">מחיר</th>
                <th className="border px-2 py-1">סטטוס</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order) => (
                <tr key={order.id}>
                  <td className="border px-2 py-1">{order.date}</td>
                  <td className="border px-2 py-1">{order.movies.join(', ')}</td>
                  <td className="border px-2 py-1">{order.price} ₪</td>
                  <td className="border px-2 py-1">
                    {order.completed ? 'טופל' : 'לא טופל'}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </DialogPanel>
      </div>
    </Dialog>
  );
}
