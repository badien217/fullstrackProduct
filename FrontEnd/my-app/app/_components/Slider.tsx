'use client'
import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from "@/components/ui/carousel"
import React, { useEffect, useState } from 'react'
import Image from "next/image"
import GlobalApi from "../Utils/GlobalApi"
interface SlideProds{
  sliderList : any[]
}
export const Slider : React.FC<SlideProds> = ({sliderList} : SlideProds) => {
 
  return (
    <Carousel>
      <CarouselContent>
        {sliderList.map((slider: any, index: any) => {
          const imageUrl = slider.attributes?.image?.data[0]?.attributes?.url;
          return (
            <CarouselItem key={index}>
              {imageUrl && (
                <Image
                  src={`${process.env.NEXT_PUBLIC_BACKEND_BASE_URL}${imageUrl}`}
                  width={1000}
                  height={400}
                  alt="slider"
                  className="w-full h-[200px] md:h-[400px] object-over rounded-s-2xl"
                />
              )}
              
            </CarouselItem>
          );
        })}
        
      </CarouselContent>
      <CarouselPrevious />
      <CarouselNext />
    </Carousel>
  )
}