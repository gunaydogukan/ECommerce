"use client";

import { useState } from "react";
import { Button } from "@/components/ui/button";
import { useAuth } from "@/hooks/use-auth";
import { addToCartServer } from "@/services/cart/cart.server";

interface AddToCartButtonProps {
    productId: number;
    disabled?: boolean;
}

export function AddToCartButton({ productId, disabled }: AddToCartButtonProps) {
    const [isLoading, setIsLoading] = useState(false);
    const { isAuthenticated } = useAuth();

    const handleAddToCart = async () => {
        if (!isAuthenticated) {
            alert("Sepete eklemek için giriş yapmalısınız!");
            return;
        }

        try {
            setIsLoading(true);

            await addToCartServer({ productId, quantity: 1 });

        } catch (error) {
            console.error('Sepete ekleme hatası:', error);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <Button
            size="sm"
            onClick={handleAddToCart}
            disabled={disabled || isLoading}
        >
            {isLoading ? "Ekleniyor..." : "Sepete Ekle"}
        </Button>
    );
}
