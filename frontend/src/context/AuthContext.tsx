"use client";

import { createContext, useEffect, useState } from "react";
import { getAuthStatus, logout as authLogout } from "@/services/auth/auth.client";

interface AuthContextType {
    isAuthenticated: boolean;
    setIsAuthenticated: (value: boolean) => void;
    logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({ children }: { children: React.ReactNode }) {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        setIsAuthenticated(getAuthStatus());
    }, []);

    const logout = () => {
        authLogout();
        setIsAuthenticated(false);
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, setIsAuthenticated, logout }}>
            {children}
        </AuthContext.Provider>
    );
}
