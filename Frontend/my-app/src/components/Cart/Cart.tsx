
import React, { FC } from 'react';
import './Cart.scss';
import { useSelector, useDispatch } from 'react-redux';
import { MovieObject } from '../../models/Movie';
import {
  removeFromCart,
  increaseQuantity,
  decreaseQuantity,
} from '../../redux/cartSlice';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; // עיצוב ברירת מחדל
// הרחבת MovieObject עם quantity
interface CartItem extends MovieObject {
  quantity: number;
}

interface CartProps {}

const Cart: FC<CartProps> = () => {
  const cart = useSelector(
    (state: { myCart: { items: CartItem[] } }) => state.myCart.items
  );
  const dispatch = useDispatch();

  const handleIncrease = (productId: number) => {
    dispatch(increaseQuantity(productId));
  };
const handleCheckout = () => {
  // כאן תוכלי לשים מה שתרצי שיקרה כשעוברים לתשלום
  toast.success(`ביצאת הזמנת סרט`, {
      position: "top-center",
      autoClose: 2000,
      hideProgressBar: true,
      closeOnClick: true,
      pauseOnHover: false,
      draggable: false,
    });
  // לדוגמה, ניווט לדף אחר:
  // navigate('/checkout'); אם את משתמשת ב-react-router
};

  const handleDecrease = (productId: number) => {
    dispatch(decreaseQuantity(productId));
  };

  const handleRemove = (productId: number) => {
    dispatch(removeFromCart(productId));
  };

  return (
    <div className="cart-container">
      <h2>עגלת קניות</h2>
      {cart.length === 0 ? (
        <p>הסל שלך ריק</p>
      ) : (
        <div>
          <div className="cart-items">
            {cart.map((product: CartItem) => (
              <div className="cart-item" key={product.Id}>
                <img
                  src={product.Image}
                  alt={product.Name}
                  className="cart-item-image"
                />
                <div className="cart-item-details">
                  <h4>{product.Name}</h4>
                  <p>{product.Description}</p>
                  <p className="cart-item-price">
                    ₪ {(product.Price ?? 0 * product.quantity).toFixed(2)}
                  </p>

                  <div className="cart-item-quantity">
                    <button
                      className="quantity-btn"
                      onClick={() => handleDecrease(product.Id)}
                    >
                      -
                    </button>
                    <span className="quantity">{product.quantity}</span>
                    <button
                      className="quantity-btn"
                      onClick={() => handleIncrease(product.Id)}
                    >
                      +
                    </button>
                  </div>

                  <button
                    className="remove-btn"
                    onClick={() => handleRemove(product.Id)}
                  >
                    הסר
                  </button>
                </div>
              </div>
            ))}
          </div>

          <div className="cart-summary">
            <strong>סך הכל:</strong> ₪{' '}
            {cart
              .reduce((total: number, item: CartItem) => {
                const price = item.Price ?? 0;
                return total + price * item.quantity;
              }, 0)
              .toFixed(2)}
<button className="checkout-btn" onClick={handleCheckout}>
  לצאת לתשלום
</button>

          </div>
<ToastContainer />
          
        </div>
      )}
    </div>
  );
};

export default Cart;
