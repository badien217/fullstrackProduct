import React, { useEffect, useState } from 'react';
import Image from 'next/image';
import { TractorIcon, TrashIcon } from 'lucide-react';
import { Button } from '@/components/ui/button';

interface CartItemListProp {
  cartItemList: any[];
  onDeleteItem : any
}

export const CartItemList = ({ cartItemList,onDeleteItem }: CartItemListProp) => {
  useEffect(() => {
    let total = 0
    cartItemList.forEach(e => {
      total = total + e.amount
    });
    setSubtotal(total)
  }, [cartItemList]);
  const [subtotal, setSubtotal] = useState(0)
  return (
    <div>
      <div className='h-[500px] overflow-auto'>
        {cartItemList.map((cart: any, index: any) => (
          <div key={index} className='flex justify-between items-center p-2'>
            <div className='flex gap-6 items-center'> {/* Add a unique key for each item */}
              {/* Check if image is defined before using it */}
              {cart.image && (
                <Image
                  src={process.env.NEXT_PUBLIC_BACKEND_BASE_URL + cart.image}
                  width={70}
                  height={80}
                  alt={cart.name || 'Product Image'} // Use name or default alt text
                  className='border p-2'
                />
              )}
              <div>
                <h2 className='font-bold'>{cart.name}</h2>
                <h2 className=''>Quantity{cart.quantity}</h2>
                <h2 className='text-lg font-bold'>${cart.amount}</h2>
              </div>
            </div>
            <TrashIcon onClick={()=>onDeleteItem(cart.id)}/>
          </div>
        ))}
      </div>
      
    </div>

  );
};

export default CartItemList;