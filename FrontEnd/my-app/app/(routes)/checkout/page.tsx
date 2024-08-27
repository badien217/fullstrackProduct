'use client'
import { Input } from '@/components/ui/input'
import { Button } from '@/components/ui/button'
import React, { useEffect, useState } from 'react'
import { ArrowBigRight } from 'lucide-react'
import GlobalApi from '@/app/Utils/GlobalApi'
import { useRouter } from 'next/navigation'
import { PayPalButtons } from '@paypal/react-paypal-js'

function checkout() {
    const jwt = sessionStorage.getItem('jwt')
    const user = JSON.parse(sessionStorage.getItem('user') || '{}')
    const [totalItems, setTotalItem] = useState<number>(0)
    const [cartItemList, setCartItemList] = useState([]);
    const router = useRouter();
    const [username,setUsername]=useState<String>();
    const [email,setEmail]=useState<String>();

    const [phone,setPhone]=useState<String>();

    const [zip,setZip]=useState<String>();
    const [totalAmounts,setTotalAmounts] = useState();

    const getCartItem = async () => {
        const cartItem = await GlobalApi.getCartItem(user.id, jwt)

        setTotalItem(cartItem?.length)
        setCartItemList(cartItem)
    }
    useEffect(()=>{
        // if(!jwt){
        //     router.push('/sign_in')
        // }
        getCartItem();
    },[])
    const [subtotal, setSubtotal] = useState(0)
    useEffect(() => {
        let total = 0;
        (cartItemList as any[]).forEach(e => { // Cast cartItemList to any[]
          total = total + e.amount;
        });
        
        setSubtotal(total);
      }, [cartItemList]);
      const calculateTotalAmount=()=>{

        const totalAmount = subtotal * 0.9 + 15
 
        return totalAmount;
      }
    return (
        <div>
            <h2 className='p-3 bg-primary text-xl text-center text-white'>Checkout</h2>
            <div className='p-5 px-5 md:px-10 grid grid-cols-1 md:grid-cols-3 py-8'>
                <div className='md:col-span-2 mx-20'>
                    <h2 className='font-bold text-3xl'> Billing Details</h2>
                    <div className='grid grid-cols-2 gap-10 mt-3'>
                        <Input placeholder='Name' onChange={(e)=> setUsername(e.target.value)}/>
                        <Input placeholder='Email'onChange={(e)=> setEmail(e.target.value)}/>

                    </div>
                    <div className='grid grid-cols-2 gap-10 mt-3'>
                        <Input placeholder='Phone' onChange={(e)=> setPhone(e.target.value)}/>
                        <Input placeholder='Zip' onChange={(e)=>setZip(e.target.value)}/>

                    </div>
                    <div className='mt-3'>
                        <Input placeholder='Address' />
                    </div>
                </div>
                <div className='mx-10 border'>
                    <h2 className='p-3 bg-gray-200 font-bold text-center'>Total Cart ({totalItems})</h2>
                    <div className='p-4 flex flex-col gap-4'>
                        <h2 className='font-bold flex justify-between'><span>${subtotal}</span></h2>
                        <hr />
                        <h2 className='flex justify-between'>Delevery: <span>$15:00</span></h2>
                        <h2 className='flex justify-between'>Tax(9%): <span>$25:00</span></h2>
                        <hr />
                        <h2 className='font-bold flex justify-between'>Total: <span>${calculateTotalAmount()}</span></h2>
                        <Button >Payment <ArrowBigRight/></Button>
                        <PayPalButtons style={{ layout: "horizontal" }}
                        createOrder={(data:any,action:any)=>{
                            return action.order.create(
                                {
                                    purchase_units:[
                                        {
                                            amount:{
                                                value:calculateTotalAmount(),
                                                currency_code:'USD'
                                            }
                                        }
                                    ]
                                }
                            )
                        }} />
                        
                    </div>
                </div>
            </div>


        </div>
    )
}

export default checkout