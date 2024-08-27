'use client'
import React, { useEffect, useState } from 'react'
import GlobalApi from '../Utils/GlobalApi';
import { ProductItems } from './ProductItems';
interface PropsProduct {
    productList : any[]
}
export const Product : React.FC<PropsProduct> =({productList} : PropsProduct) => {
  
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
