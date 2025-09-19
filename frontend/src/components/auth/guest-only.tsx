"use client";

import { useEffect, ReactNode } from "react";
import { useRouter } from "next/navigation";
import { ROUTES } from "@/lib/constants";

export function GuestOnly({ children }: { children: ReactNode }) {
    const router = useRouter();

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (token) {
            router.replace(ROUTES.HOME);
        }
    }, [router]);

    return <>{children}</>;
}
