"use server";

import { getMyFavoritesServer } from "@/services/favorite/favorite.server";
import { FavoriteList } from "@/features/favorites/favorite-list";
import { FavoritesInitializer } from "@/features/products/favorites-initializer";

export default async function FavoritesMyPage() {
    const favorites = await getMyFavoritesServer();
    const favoriteIds = favorites.map(f => f.productId);

    return (
        <main className="container mx-auto py-8">
            <h1 className="text-2xl font-bold mb-6">Favorilerim</h1>

            <FavoritesInitializer favorites={favoriteIds} />
            <FavoriteList favorites={favorites} />
        </main>
    );
}
