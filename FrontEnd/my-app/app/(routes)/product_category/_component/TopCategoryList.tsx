'use client'
import React, { useEffect, useState } from 'react'
import Link from 'next/link'
import Image from 'next/image'
import GlobalApi from '@/app/Utils/GlobalApi';
 
   
    
    export default function TopCategoryList() {
      const [categoriesList,setCategory] = useState([])
       useEffect(()=>{
        getCategoryList();
    },[])
    const  getCategoryList = ()=>{
        GlobalApi.getCategory().then(resp =>{  
        setCategory(resp.data.data);
        })        
    }
   
      return (
        <div className='flex gap-5 mt-2 overflow-auto mx-7 md:mx-20 justify-center'>
          {categoriesList.map((category: any, index: any) => (
            <Link
              href={'/product_category/' + category.attributes.name}
              className='flex flex-col items-center bg-green-50 gap-2 p-3 rounded-lg group cursor-pointer hover:bg-green-200 w-[500px] min-w-[100px]'
            >
              <Image
                src={process.env.NEXT_PUBLIC_BACKEND_BASE_URL + category?.attributes?.icon?.data[0]?.attributes?.url}
                unoptimized={true}
                width={50}
                height={50}
                alt='icon'
                className='group-hover:scale-125 transition-all ease-in-out'
              />
              <h2 className='text-green-800'>{category.attributes.name}</h2>
            </Link>
          ))}
        </div>
      );
    }