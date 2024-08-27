
import { Button } from "@/components/ui/button";
import Image from "next/image";
import { Slider } from "./_components/Slider";
import GlobalApi from "./Utils/GlobalApi";
import { CategoryList } from "./_components/CategoryList";
import { Product } from "./_components/Product";
import { Footer } from "./_components/Footer";
type Prop ={
  sliderList: any[],
  categories:any[],

}
export default async function Home() {
  const slider = await GlobalApi.getSlider();
  const categories = await GlobalApi.getCategorise();
  const product = await GlobalApi.getProduct();
  return (
    <div className="p-5 md:p-10 px-16">
      <Slider sliderList = {slider} />
      <CategoryList categories ={categories}/>
      <Product productList = {product}/>
      <Image src='/banner.jpg' width={1000} height={300} alt="banner" className="w-full mt-10  h-[200px] object-contain" />
      <Footer/>
    </div>
    
  );
}
