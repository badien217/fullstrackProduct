import React, { useContext, useState } from 'react'
import Image from 'next/image'
import { Button } from '@/components/ui/button'
import { LoaderCircle, ShoppingBasket } from 'lucide-react'
import { Item } from '@radix-ui/react-dropdown-menu'
import { useRouter } from 'next/navigation'
import GlobalApi from '../Utils/GlobalApi'
import { Toast } from '@/components/ui/toast'
import { useToast } from '@/components/ui/use-toast'
import { UpdateCartContext } from '../_context/UpdateCartContext'


export const ProductItemsDetails = ({ product }: any) => {
    const jwt = sessionStorage.getItem('jwt')
    const {toast} = useToast()
    const {updateCart,setUpdateCart} = useContext(UpdateCartContext);
    const user = JSON.parse(sessionStorage.getItem('user')|| '{}')
    const [loading,setLoaing] = useState<boolean>(false)
    const [productTotalPrice,setProductTotalPrices] = useState(
        product.attributes.sellingPrice?
        product.attributes.sellingPrice:
        product.attributes.mrp
    )
    const router = useRouter()
    const [quantity,setQuantity]= useState(1)
    
    const AddToCart =()=>{
        setLoaing(true)
        if(!jwt){
            router.push('/')
            setLoaing(false)
            return;    
        }
        const data ={
            data:{quantity:quantity,
                amount:Number.parseFloat((quantity * productTotalPrice ).toFixed(2)),
                products:product.id,
                users_permissions_user:user.id,
                userId:Number.parseInt(user.id)
            }
        }
        console.log(data)
        GlobalApi.addToCart(data,jwt).then(resp =>{
            console.log(resp)
            toast({title:"Add to Cart"});
            setUpdateCart(!updateCart)
            setLoaing(false)
        },(e)=>{
            toast({title:"Error while adding into cart"})
        })

    }
    return (
        <div className='grid grid-cols-1 md:grid-cols-2 p-7 bg-white text-black'>
        <Image 
            src={`${process.env.NEXT_PUBLIC_BACKEND_BASE_URL}${product.attributes.image.data[0].attributes.url}`} 
            alt='image' 
            width={300} 
            height={300}
            className='bg-slate-200 p-5 h-[300px] w-[300px] object-contain rounded-lg'
        />
        <div className='flex flex-col gap-3'>
            <h2 className='text-2xl font-bold'>{product.attributes.name}</h2>
            <h2 className='text-sm text-gray-500'>{product.attributes.description}</h2><br />
            <div className='flex gap-3'>
                {product.attributes.sellingPrice && (
                    <h2 className='font-bold text-3xl'>
                        ${product.attributes.sellingPrice}
                    </h2>
                )}
                <h2 className={`font-bold text-3xl ${product.attributes.sellingPrice && 'line-through text-gray-500'}`}>
                    ${product.attributes.mrp}
                </h2>
            </div>
            <h2 className='font-medium text-lg'>Quantity {product.attributes.itemQuantityType}</h2>
            <div className='flex flex-col items-baseline gap-3'>
                <div className='flex gap-3 items-center'>
                <div className='p-2 border flex gap-10 items-center px-5 '>
                    <button disabled={quantity==1} onClick={() => setQuantity(quantity-1)}>-</button>
                    <h2>{quantity}</h2>
                    <button onClick={() => setQuantity(quantity+1)} >+</button>
                </div>
                <h2 className='text-2xl font-bold'> $ {(quantity * productTotalPrice).toFixed(2)}</h2>
                </div>
                <Button className="flex gap-3" onClick={() => AddToCart()} disabled={loading}>
                    <ShoppingBasket/>{loading?<LoaderCircle className='animate-spin'/>: 'Add to cart'}
                </Button>

            </div>
            <h2><span>Category: </span>{product.attributes.categories.data[0].attributes.name}</h2>
        </div>
    </div>

    )
}
