
import GlobalApi from '@/app/Utils/GlobalApi'
import React from 'react'
import TopCategoryList from '../_component/TopCategoryList';
import ProductList from '../_component/ProductList';
import { List } from 'lucide-react';
type PrivateProps ={
  productList : [];
}

export default  async function  ProductCategory({ params }: any){
  const productList = await  GlobalApi.getProductByCategory(params.categoryName)
  
  const category = await  GlobalApi.getCategorise();
  
  return (
    <div>
      <h2 className='p-4 bg-primary text-white font-bold text-3xl text-center'>{params.categoryName}</h2>
      <TopCategoryList  />
      <ProductList productList = {productList}/>
    </div>
  );
}