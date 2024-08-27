
import { createContext, Dispatch, FC, ReactNode, SetStateAction, useState } from "react";
export const UpdateCartContext = createContext<{ updateCart: boolean; setUpdateCart: Dispatch<SetStateAction<boolean>>; }>(
    { updateCart: false, setUpdateCart: () => {} } // Provide default values
  );