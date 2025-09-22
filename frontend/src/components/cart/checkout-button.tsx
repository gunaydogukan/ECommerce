"use client";

import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import { createOrderServer } from "@/services/order/order.server";
import { useState } from "react";
import { useAtom } from "jotai";
import { isAuthenticatedAtom } from "@/stores/auth-atom";

export function CheckoutButton() {
    const router = useRouter();
    const [loading, setLoading] = useState(false);
    const [isAuthenticated] = useAtom(isAuthenticatedAtom);

    const handleCheckout = async () => {
        if (!isAuthenticated) {
            alert("Sepeti satın almak için giriş yapmalısınız!");
            router.push("/auth/login");
            router.refresh();
            return;
        }

        try {
            setLoading(true);
            await createOrderServer({ items: [] });
            alert("Siparişiniz başarıyla oluşturuldu!");
            //router.push("/orders/my");
        } catch (err: any) {
            alert(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <Button
            size="lg"
            //className="bg-blue-600 hover:bg-blue-700 text-white rounded-lg px-6"
            disabled={loading}
            onClick={handleCheckout}
        >
            {loading ? "Sipariş veriliyor..." : "Hepsini Al"}
        </Button>
    );
}
