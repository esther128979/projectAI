import React, { FC, useState } from 'react';
import {
  List, Button, Typography, Dialog, DialogTitle, DialogContent, IconButton, Box
} from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import './OrderList.scss';
import { MovieObject } from '../../models/Movie';
import Movie from '../Movie/Movie';
import OrderDialog from '../OrderDialog/OrderDialog';
import { submitOrder } from '../../services/ordersService';



interface OrderListProps {
}

const OrderList: FC<OrderListProps> = () => {
  

  return (
    <div className="OrderList">
      
    </div>
  );
};

export default OrderList;
