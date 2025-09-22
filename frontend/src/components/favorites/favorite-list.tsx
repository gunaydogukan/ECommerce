"use client";

import { MyFavoriteResponse } from "@/services/favorite/types";
import { ProductCard } from "@/components/products/product-card";
import { PLACEHOLDER_IMAGE } from "@/lib/constants";

interface FavoriteListProps {
    favorites: MyFavoriteResponse[];
    showAddToCart?: boolean;
    canEdit?: boolean;
}

export function FavoriteList({
                                 favorites,
                                 showAddToCart = true,
                                 canEdit = false,
                             }: FavoriteListProps) {
    if (!favorites || favorites.length === 0) {
        return (
            <div className="text-center py-12 text-gray-500">
                Henüz favori ürününüz yok.
            </div>
        );
    }

    return (
        <div className="grid gap-4 md:gap-6 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
            {favorites.map((fav) => (
                <ProductCard
                    key={fav.id}
                    product={{
                        id: fav.productId,
                        name: fav.productName,
                        description: "",
                        categoryId: 0,
                        price: fav.price,
                        imageUrl: PLACEHOLDER_IMAGE,
                        userId: 0,
                        createdAt: undefined,
                        updatedAt: undefined,
                    }}
                    showAddToCart={showAddToCart}
                    canEdit={canEdit}
                />
            ))}
        </div>
    );
}
