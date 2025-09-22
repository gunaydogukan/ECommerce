"use server";

import { getProductsServer } from "@/services/product/product.server";
import { getMyFavoritesServer } from "@/services/favorite/favorite.server";
import { ProductGrid } from "@/components/products/list/product-grid";
import {FavoritesInitializer} from "@/components/products/favorites-initializer";

export default async function ProductsPage() {
    const products = await getProductsServer();
    const favorites = await getMyFavoritesServer();
    const favoriteIds = favorites.map(f => f.productId);

    return (
        <main className="container mx-auto py-8">
            <FavoritesInitializer favorites={favoriteIds} />
            <ProductGrid products={products} />
        </main>
    );
}
