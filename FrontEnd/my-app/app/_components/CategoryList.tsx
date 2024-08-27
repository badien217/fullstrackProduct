'use client'
import React, { useEffect, useState } from 'react'
import GlobalApi from '../Utils/GlobalApi';
import Image from 'next/image';
import Link from 'next/link';
interface categoryProps{
    categories : any[]
}
export const CategoryList: React.FC<categoryProps> = ({categories} : categoryProps) => {

  return ( 
    <div>
        <h2 className='text-green-600 font-bold-text-lg'>Shop by Category</h2>
        <div className='grid grid-cols-3 sm:grid-cols-4 md:grid-cols-5 lg:grid-cols-7 gap-5 mt-2'>
            {categories.map((category:any ,index:any)=>(
                <Link key ={index} href={'/product_category/' + category.attributes.name} className='flex flex-col items-center bg-green-50 
                gap-2 p-3 rounded-lg group cursor-pointer hover:bg-green-200' >
                    <Image src={process.env.NEXT_PUBLIC_BACKEND_BASE_URL+
                        category?.attributes?.icon?.data[0]?.attributes?.url}
                        unoptimized ={true}
                        width={50}
                        height={50}
                    alt='icon'
                    className='group-hover:scale-125 transition-all ease-in-out'/>
                    <h2 className='text-green-800'>{category.attributes.name}</h2>
                </Link> 
            ))}
        </div>
    
    </div>
  )
}
