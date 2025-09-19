"use client";

import { useState } from "react";
import { Button } from "@/components/ui/button";

interface AddToCartButtonProps {
    productId: number;
    disabled?: boolean;
}

export function AddToCartButton({ productId, disabled }: AddToCartButtonProps) {
    const [isLoading, setIsLoading] = useState(false);

    const handleAddToCart = async () => {
        setIsLoading(true);
        try {
            console.log(`Ürün ${productId} sepete eklendi`);
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
