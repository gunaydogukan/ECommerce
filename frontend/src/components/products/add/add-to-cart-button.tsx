"use client";

import { useState } from "react";
import { Button } from "@/components/ui/button";
import { addToCartServer } from "@/services/cart/cart.server";
import {useAtom} from "jotai";
import {isAuthenticatedAtom} from "@/stores/auth-atom";

interface AddToCartButtonProps {
    productId: number;
    disabled?: boolean;
}

export function AddToCartButton({ productId, disabled }: AddToCartButtonProps) {
    const [isLoading, setIsLoading] = useState(false);
    const [isAuthenticated] = useAtom(isAuthenticatedAtom);

    const handleAddToCart = async () => {
        if (!isAuthenticated) {
            alert("Sepete eklemek için giriş yapmalısınız!");
            return;
        }

        try {
            setIsLoading(true);
            await addToCartServer({ productId, quantity: 1 });
            console.log("Eklendi");
        } catch (error) {
            console.error('Sepete ekleme hatası:', error);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <Button
            size="sm"
            className="text-xs px-2 py-1"
            onClick={handleAddToCart}
            disabled={disabled || isLoading}
        >
            {isLoading ? "Ekleniyor..." : "Sepete Ekle"}
        </Button>
    );
}
