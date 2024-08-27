import React from 'react'
import Image from 'next/image'
import { Button } from '@/components/ui/button'
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog"
import { ProductItemsDetails } from './ProductItemsDetails'

export const ProductItems = ({product} : any) => {
  return (
    <div className='p-2 md:p-6
    flex flex-col items-center
    justify-center gap-3 border rounded-lg
    hover:scale-110 hover:shadow-md
    transition-all ease-in-out'>
        <Image src={process.env.NEXT_PUBLIC_BACKEND_BASE_URL+
            product.attributes.image.data[0].attributes.url
        } alt={product.attributes.name}
        width={500}
        height={200}
        className='h-[200px] w-[400px] object-contain'/>
        <div className='flex gap-3'>
        <b><h2 className='font-bold text-lg'>{product.attributes.name}</h2></b>
        {product.attributes.sellingPrice && <h2 className='font-bold text-lg'>
            ${product.attributes.sellingPrice}
            </h2>}
        <b><h2 className={`font-bold text-lg ${product.attributes.sellingPrice && 'line-through text-gray-500 '}` }>${product.attributes.mrp}</h2></b>
        </div>
    
        
        <Dialog>
        <DialogTrigger>
          <Button variant ="outline"
        className='text-primary hover:text-white hover:bg-primary'
        > Add to cart</Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle></DialogTitle>
            <DialogDescription>
             <ProductItemsDetails product ={product}/>
            </DialogDescription>
          </DialogHeader>
        </DialogContent>
      </Dialog>

    </div>
  )
}
