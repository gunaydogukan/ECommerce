"use client";

import { useEffect, ReactNode, useState } from "react";
import { useRouter } from "next/navigation";
import { ROUTES } from "@/lib/constants";

export function ProtectedRoute({ children }: { children: ReactNode }) {
    const router = useRouter();
    const [checked, setChecked] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (!token) {
            router.replace(ROUTES.LOGIN);
        } else {
            setChecked(true);
        }
    }, [router]);

    if (!checked) return null;

    return <>{children}</>;
}
