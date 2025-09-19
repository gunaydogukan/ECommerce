"use client";

import { createContext, useState } from "react";
import { getCookieServer } from "@/lib/getCookie.server";

interface AuthContextType {
    isAuthenticated: boolean;
    setIsAuthenticated: (value: boolean) => void;
    logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({
                                 children,
                                 initialAuth = false,
                             }: {
    children: React.ReactNode;
    initialAuth?: boolean;
}) {
    const [isAuthenticated, setIsAuthenticated] = useState(initialAuth);

    const logout = async () => {
        await getCookieServer();
        setIsAuthenticated(false);
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, setIsAuthenticated, logout }}>
            {children}
        </AuthContext.Provider>
    );
}
