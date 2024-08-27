'use client'
import React, { useState } from 'react'
import Image from 'next/image'
import { Input } from '@/components/ui/input'
import { Button } from '@/components/ui/button'
import Link from 'next/link'
import GlobalApi from '@/app/Utils/GlobalApi'
import { Emblema_One } from 'next/font/google'
import { LoaderIcon, Route } from 'lucide-react'
import { useRouter } from 'next/navigation'
import { toast, useToast } from '@/components/ui/use-toast'
import { Toast } from '@/components/ui/toast'

function CreateAccount() {
  const { toast } = useToast()
  const [username,setUseName] = useState<string>();
  const [email,setEmail] = useState<string>();
  const [password,setPassWord] = useState<string>();
  const router = useRouter();
  const [loader,setLoader] = useState<boolean>();
  const onCreateAccount =()=>{
    setLoader(true)
    GlobalApi.registerUser(username??"",email??"",password??"").then(resp =>{
      console.log(resp.data.user);
      console.log(resp.data.jwt);
      sessionStorage.setItem('user',JSON.stringify(username))
      sessionStorage.setItem('jwt',resp.data.jwt)
      toast({title:"Success",
        description:"Account Created Successfully"
      })
      router.push('/')
      setLoader(false)

    },(e) =>{
      toast({title:"Error",
        description:"you need check to information"
      })
      setLoader(false)
    })
  }
  return (

    <div className='flex items-baseline justify-center my-10'>
      <div className='flex flex-col items-center justify-center
      p-10 bg-slate-100 border-gray-200'>
        <Image src='/logo.png' width={200} height={200} alt='logo' />
        <h2 className='font-bold text-3xl'>Create an Account</h2>
        <h2 className='text-gray-500'>Enter your email and Password</h2>
        <div className='w-full flex flex-col gap-5 mt-7'>
          <Input placeholder='Username' onChange={(e) => setUseName(e.target.value)}/>
          <Input placeholder='name@example.com' onChange={(e) => setEmail(e.target.value)}/>
          <Input type='password' placeholder='Password' onChange={(e) => setPassWord(e.target.value)}/>
          <Button onClick={()=>onCreateAccount()}
            disabled={!{username,email,password}}>
              {loader?<LoaderIcon className='animate-spin'/>:'Create an Account' }</Button>
          <p>Already have an Account</p>
          <Link href={'/sign_in'} className='text-blue-500'>
          Click here to Sign In
          </Link>


        </div>
      </div>
    </div>
  )
}

export default CreateAccount