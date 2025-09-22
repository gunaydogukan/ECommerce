"use client";

import { useSetAtom } from "jotai";
import { useEffect } from "react";
import { favoritesAtom } from "@/stores/favorites-atom";

interface FavoritesInitializerProps {
    favorites: number[];
}

export function FavoritesInitializer({ favorites }: FavoritesInitializerProps) {
    const setFavorites = useSetAtom(favoritesAtom);

    useEffect(() => {
        setFavorites(favorites);
    }, [favorites, setFavorites]);

    return null;
}
