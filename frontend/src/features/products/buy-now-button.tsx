"use client";

import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import { createOrderServer } from "@/services/order/order.server";
import { useState } from "react";
import { useAtom } from "jotai";
import { isAuthenticatedAtom } from "@/stores/auth-atom";

interface BuyNowButtonProps {
    productId: number;
}

export function BuyNowButton({ productId }: BuyNowButtonProps) {
    const router = useRouter();
    const [loading, setLoading] = useState(false);
    const [isAuthenticated] = useAtom(isAuthenticatedAtom);

    const handleBuyNow = async () => {
        if (!isAuthenticated) {
            alert("Satın alma işlemi için giriş yapmalısınız!");
            router.push("/auth/login");
            return;
        }

        try {
            setLoading(true);
            await createOrderServer({
                items: [{ productId, quantity: 1 }],
            });
            alert("Sipariş başarıyla oluşturuldu!");
            //router.push("/orders/my");
        } catch (err: any) {
            alert(err.message);
        } finally {
            setLoading(false);
        }
    };

    return (
        <Button
            size="sm"
            variant="default"
            className="text-xs px-2 py-1"
            onClick={handleBuyNow}
            disabled={loading}
        >
            {loading ? "Sipariş veriliyor..." : "Satın Al"}
        </Button>
    );
}
