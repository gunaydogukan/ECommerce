"use client";

import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card";
import { Product } from "@/services/product/types";
import { AddToCartButton } from "./add-to-cart-button";
import { PLACEHOLDER_IMAGE } from "@/lib/constants";

interface ProductCardProps {
    product: Product;
    showAddToCart?: boolean;
}

export function ProductCard({ product, showAddToCart = true }: ProductCardProps) {
    return (
        <Card className="flex flex-col overflow-hidden">
            <CardHeader className="p-0">
                <img
                    src={product.imageUrl || PLACEHOLDER_IMAGE}
                    alt={product.name}
                    className="h-48 w-full object-cover"
                />
            </CardHeader>

            <CardContent className="p-4 flex-1">
                <h3 className="text-lg font-semibold truncate">{product.name}</h3>
                <p className="mt-1 text-sm text-gray-600 truncate">
                    {product.description || "—"}
                </p>
            </CardContent>

            <CardFooter className="flex items-center justify-between p-4">
        <span className="text-lg font-bold text-blue-600">
          {product.price.toLocaleString("tr-TR")} ₺
        </span>
                {showAddToCart && <AddToCartButton productId={product.id} />}
            </CardFooter>
        </Card>
    );
}
