"use client"
import React, { useContext, useEffect, useState } from 'react'
import Image from 'next/image'
import { CircleUserRound, Import, LayoutGrid, Search, ShoppingBag, ShoppingBasket } from 'lucide-react'
import { Button } from '@/components/ui/button'
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import GlobalApi from '../Utils/GlobalApi'
import axios from 'axios'
import Link from 'next/link'
import { useRouter } from 'next/navigation'
import { UpdateCartContext } from '../_context/UpdateCartContext'
import {
    Sheet,
    SheetClose,
    SheetContent,
    SheetDescription,
    SheetHeader,
    SheetTitle,
    SheetTrigger,
} from "@/components/ui/sheet"
import CartItemList from './CartItemList'
import { toast, useToast } from '@/components/ui/use-toast'
import { title } from 'process'

const Headers = () => {
    const { toast } = useToast()
    const jwt = sessionStorage.getItem('jwt')
    const router = useRouter();
    const [cartItemList, setCartItemList] = useState([]);
    const [categoryList, setCategoryList] = useState([]);
    const user = JSON.parse(sessionStorage.getItem('user') || '{}')
    const isLogin = sessionStorage.getItem('jwt') ? true : false;
    const [totalItems, setTotalItem] = useState<number>(0)
    const [subtotal, setSubtotal] = useState(0)
    useEffect(() => {
        let total = 0;
        (cartItemList as any[]).forEach(e => { // Cast cartItemList to any[]
          total = total + e.amount;
        });
        setSubtotal(total);
      }, [cartItemList]);
    useEffect(() => {
        getCategoryList();

    }, [])
    useEffect(() => {
        getCartItem()
    })

    const getCategoryList = () => {
        GlobalApi.getCategory().then(resp => {


            setCategoryList(resp.data.data);
        })
    }
    const SignOut = () => {
        sessionStorage.clearAll();
        router.push('/sign-in')
    }
    const getCartItem = async () => {
        const cartItem = await GlobalApi.getCartItem(user.id, jwt)

        setTotalItem(cartItem?.length)
        setCartItemList(cartItem)
    }
    const onDeleteItem = (id: any) => {
        GlobalApi.deleteCartItems(id, jwt).then(resp => {
            toast({ title: "Items removed!" })
            getCartItem();
        })
    }
    return (
        <div className=' p-5 shadow-md flex justify-between'>
            <div className='flex items-center gap-8'>
                <Image src='/logo.png' alt='logo'
                    width={150}
                    height={100}
                />

                <DropdownMenu>
                    <DropdownMenuTrigger>
                        <h2 className='hidden md:flex gap-2 items-center
                            border rounded-full p-2 px-10 bg-slate-200 cursor-pointer
                            '>
                            <LayoutGrid className='h-5 w-5' /> Category
                        </h2></DropdownMenuTrigger>
                    <DropdownMenuContent>
                        <DropdownMenuLabel>My Account</DropdownMenuLabel>
                        <DropdownMenuSeparator />
                        {categoryList.map((categories: any, index) => (
                            <Link key={index} href={'/product_category/' + categories.attributes.name}>
                                <DropdownMenuItem className='flex gap-2 items-center' >
                                    <Image src={
                                        process.env.NEXT_PUBLIC_BACKEND_BASE_URL +
                                        categories?.attributes?.icon?.data[0]?.attributes?.url}
                                        unoptimized={true}
                                        alt='icon'
                                        width={27}
                                        height={27}
                                    ></Image>
                                    <h2 className='text-lg'>{categories?.attributes?.name}</h2>

                                </DropdownMenuItem>
                            </Link>
                        ))}


                    </DropdownMenuContent>
                </DropdownMenu>

                <div className=' md:flex gap-7  items-center
             border rounded-full p-2 px-6 
             hidden'>
                    <Search />
                    <input type='text' placeholder='search'
                        className='outline-none' />
                </div>

            </div>
            <div className=' flex gap-3 items-center'>

                <Sheet>
                    <SheetTrigger>
                        <h2 className='flex gap-2 items-center text-lg' ><ShoppingBasket />
                            <span className='bg-primary text-white px-3 rounded-full'>{totalItems}</span></h2>
                    </SheetTrigger>
                    <SheetContent>
                        <SheetHeader>
                            <SheetTitle className='bg-primary
                             text-white font-bold text-lg p-2'>My Cart</SheetTitle>
                            <SheetDescription>
                                <CartItemList cartItemList={cartItemList} onDeleteItem={onDeleteItem} />
                            </SheetDescription>
                        </SheetHeader>
                        <SheetClose asChild>
                            <div className='absolute w-[90%] bottom-6 flex flex-col'>
                                <h2 className='text-lg font-bold flex justify-between'>Subtotal <span>${subtotal}</span></h2>

                                <Button onClick={()=> router.push(jwt?'/checkout':'/sign_in')}>Check Out</Button>
                            </div>
                        </SheetClose>
                    </SheetContent>
                </Sheet>

                {!isLogin ? < Link href={'/sign_in'}>
                    <Button>Login</Button>
                </Link>
                    : <DropdownMenu>
                        <DropdownMenuTrigger>
                            <CircleUserRound className='bg-green-100 p-2 rounded-full text-primary h-12 w-12' />
                        </DropdownMenuTrigger>
                        <DropdownMenuContent>
                            <DropdownMenuLabel>My Account</DropdownMenuLabel>
                            <DropdownMenuSeparator />
                            <DropdownMenuItem>Profile</DropdownMenuItem>
                            <DropdownMenuItem>My Order</DropdownMenuItem>
                            <DropdownMenuItem onClick={() => SignOut}>Logout</DropdownMenuItem>

                        </DropdownMenuContent>
                    </DropdownMenu>}


            </div>
        </div>
    )
}

export default Headers