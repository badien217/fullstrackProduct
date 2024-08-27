'use client'
import React, { useEffect, useState } from 'react'
import Image from 'next/image'
import { Input } from '@/components/ui/input'
import { Button } from '@/components/ui/button'
import Link from 'next/link'
import GlobalApi from '@/app/Utils/GlobalApi'
import { useToast } from '@/components/ui/use-toast'
import { useRouter } from 'next/navigation'
import { LoaderIcon } from 'lucide-react'

function SignIn() {
  const { toast } = useToast()
  const router = useRouter()
  const [email,setEmail] = useState<string>();
  const [password,setPassWord] = useState<string>();
  const [loader,setLoader] = useState<boolean>();
  useEffect(()=> {
    const jwt = sessionStorage.getItem('jwt')
    if(jwt){
      router.push('/')
    }
  },[])
  const onSignIn=()=> {
    setLoader(true)
    GlobalApi.SignIn(email??"",password??"").then(resp => {
      console.log(resp.data.user)
      console.log(resp.data.jwt)
      sessionStorage.setItem('user',JSON.stringify(resp.data.user))
      sessionStorage.setItem('jwt',resp.data.jwt)
      toast({title:"Success",
        description:"Login Successfully"
      })
      router.push('/')
      setLoader(false)
    },(e => {
      console.log(e)
      toast(e?.data?.error?.message)
      setLoader(false)
    }))
  }
  
  
  return (
    <div className='flex items-baseline justify-center my-10'>
      <div className='flex flex-col items-center justify-center
      p-10 bg-slate-100 border-gray-200'>
        <Image src='/logo.png' width={200} height={200} alt='logo' />
        <h2 className='font-bold text-3xl'>Login</h2>
        <h2 className='text-gray-500'>Enter your email and Password</h2>
        <div className='w-full flex flex-col gap-5 mt-7'>
         
          <Input placeholder='name@example.com' onChange={(e) => setEmail(e.target.value)}/>
          <Input type='password' placeholder='Password' onChange={(e) => setPassWord(e.target.value)}/>
          <Button onClick={()=>onSignIn()}
            disabled={!{email,password}}>
              {loader?<LoaderIcon className='animate-spin'/>:'sign In'}</Button>
          <p>If you don't have account</p>
          <Link href={'/create_account'} className='text-blue-500'>
          Click here to Register
          </Link>


        </div>
      </div>
    </div>
  ) 
}

export default SignIn