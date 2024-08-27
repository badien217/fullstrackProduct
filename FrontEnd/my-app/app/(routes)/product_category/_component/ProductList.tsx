'use client'
import { ProductItems } from '@/app/_components/ProductItems'
import GlobalApi from '@/app/Utils/GlobalApi'
import React, { useEffect, useState } from 'react'
interface Props {
    
    productList: any[]
}

const  ProductList: React.FC<Props>  = ({productList} : Props)=> {
   
  return (
    <div className='mt-10'>
        <h2 className='text-green-600 font-bold-text-lg'>Shop by Category</h2>
        <div className='grid
        grid-cols-2
        md:grid-cols-3
        lg:grid-cols-4
        gap-5 mt-6'>
            {productList.map((product:any ,index:any)=>index<10 &&
            (
                <ProductItems key={index} product ={product}/>
            )
            )}
        </div>
    </div>
  )
}
export default ProductList;

