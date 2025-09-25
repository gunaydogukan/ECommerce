"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import {AddFavoriteRequest, FavoriteResponse, MyFavoriteResponse} from "./types";
import { getCookieToken } from "@/lib/getCookie.server";
import { cookies } from "next/headers";

export async function addFavoriteServer(data: AddFavoriteRequest): Promise<FavoriteResponse> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.FAVORITES}/add`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        body: JSON.stringify(data),
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Favori eklenemedi");
    }

    const response = await res.json();
    return response.data;
}

export async function getMyFavoritesServer(): Promise<MyFavoriteResponse[]> {
    const token = await getCookieToken();

    if(!token){
        return [] ;
    }

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.FAVORITES}/my`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Authorization": token ? `Bearer ${token}` : "",
        },
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Favoriler getirilemedi");
    }

    const response = await res.json();
    return response.data;
}

export async function deleteFavoriteServer(productIds: number[]): Promise<void> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.FAVORITES}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        body: JSON.stringify(productIds),
        cache: "no-store",
    });
    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Favori silinemedi");
    }
}