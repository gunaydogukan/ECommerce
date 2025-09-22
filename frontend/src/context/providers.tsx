"use client";

import { useEffect } from "react";
import { useSetAtom } from "jotai";
import { isAuthenticatedAtom } from "@/stores/auth-atom";

export default function Providers({
                                      children,
                                      initialAuth = false,
                                  }: {
    children: React.ReactNode;
    initialAuth?: boolean;
}) {
    const setIsAuthenticated = useSetAtom(isAuthenticatedAtom);

    useEffect(() => {
        setIsAuthenticated(initialAuth);
    }, [initialAuth, setIsAuthenticated]);

    return <>{children}</>;
}
