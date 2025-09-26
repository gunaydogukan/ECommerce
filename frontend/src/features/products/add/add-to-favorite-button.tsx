"use client";

import { useAtom } from "jotai";
import { favoritesAtom } from "@/stores/favorites-atom";
import { Heart } from "lucide-react";
import {addFavoriteServer, deleteFavoriteServer} from "@/services/favorite/favorite.server";
import { cn } from "@/lib/utils";
import { useRouter } from "next/navigation";

interface AddToFavoriteButtonProps {
    productId: number;
}

export function AddToFavoriteButton({ productId }: AddToFavoriteButtonProps) {
    const [favorites, setFavorites] = useAtom(favoritesAtom);
    const router = useRouter();

    const isFavorite = favorites.includes(productId);

    const handleAddFavorite = async () => {
        try {
            if (isFavorite) {
                await deleteFavoriteServer([productId]);
                setFavorites(favorites.filter(f => f !== productId));
            } else {
                await addFavoriteServer({ productId });
                setFavorites([...favorites, productId]);
            }
            router.refresh();
        } catch (err: any) {
            alert(err.message || "Favori işlemi hata olustu.");
        }
    };

    return (
        <button
            onClick={handleAddFavorite}
            className="p-2 rounded-full hover:bg-gray-100"
            title={isFavorite ? "Favorilerde" : "Favorilere ekle"}
        >
            <Heart
                className={cn(
                    "w-5 h-5",
                    isFavorite
                        ? "fill-red-500 text-red-500"
                        : "text-gray-600 hover:text-red-500"
                )}
            />
        </button>
    );
}
