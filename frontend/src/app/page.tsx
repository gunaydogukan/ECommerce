"use server"

import { getProductsServer } from "@/services/product/product.server";
import { getMyFavoritesServer } from "@/services/favorite/favorite.server";
import { ProductGrid } from "@/features/products/list/product-grid";
import { FavoritesInitializer } from "@/features/products/favorites-initializer";

export default async function HomePage() {
    const products = await getProductsServer();
    let favoriteIds: number[] = [];

    try {
        const favorites = await getMyFavoritesServer();
        favoriteIds = favorites.map(f => f.productId);
    } catch (err: any) {
        if (err.message.includes("Yetkisiz")) {
            favoriteIds = [];
        } else {
            throw err;
        }
    }

    return (
        <main className="container mx-auto py-8">
            <FavoritesInitializer favorites={favoriteIds} />
            <ProductGrid products={products} />
        </main>
    );
}
