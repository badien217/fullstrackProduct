import axios from "axios";
import { headers } from "next/headers";
//const {default:axios} = require("axios");
const axiosClient = axios.create({
    baseURL : "'https://localhost:7242/api",
});
interface CartItems{
    id:any,
    name:any,
    quantity:any,
    image:any,
    actuaPrice:any,
    amount:any


}
const getCategory = ()=>axiosClient.get('/categories/GetAllCateGory');
const getCategorise = ()=>axiosClient.get('/categories/GetAllCateGory').then(resp => {
    return resp.data.data
});
const getSlider = () => axiosClient.get('/GetAllProduct').then(resp => {
    return resp.data.data
});
const getProduct =() => axiosClient.get('/GetAllProduct').then(resp => {
    return resp.data.data
});
const getProductByCategory =(category:any) => axiosClient.get('/products?filters[categories][name][$in]='+category+'&populate=*').then(resp => {
    return resp.data.data
}).catch(error => {return []})
const registerUser=(username :string,email:string,password:string)=>axiosClient.post('/auth/local/register',{
    username:username,
    email:email,
    password:password
})
const SignIn=(email:string,password:string) => axiosClient.post('/auth/local',{
    identifier:email,
    password:password
})
const addToCart=(data:any,jwt:any)=> axiosClient.post('/user-carts',data,{headers:{
    Authorization:'Bearer' + jwt
}})
const getCartItem=(userId:any,jwt:any)=> axiosClient.get('/user-carts?filters[userId][$eq]='+userId+'&[populate][products][populate][image][populate][0]=url',
    {
    headers:{
        Authorization:'bearer'+jwt
    }}).then(resp => {
        const data= resp.data.data
        const cartItems= data.map((item:any,index:any):CartItems=>({
            name:item.attributes.products?.data[0]?.attributes.name,
            quantity:item.attributes.quantity,
            amount:item.attributes.amount,
            image:item.attributes.products?.data[0]?.attributes.image.data[0].attributes.url,
            actuaPrice:item.attributes.products?.data[0]?.attributes.mrp,
            id:item.id,
        }))
        return cartItems

    }
)
const deleteCartItems=(id:any ,jwt:any)=> axiosClient.delete('/user-carts/'+id,
    {
    headers:{
        Authorization:'bearer'+jwt
    }});
export default{
    getCategory,
    getSlider,
    getProduct,
    getProductByCategory,
    getCategorise,
    registerUser,
    SignIn,
    addToCart,
    getCartItem,deleteCartItems
}