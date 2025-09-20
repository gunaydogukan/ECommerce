"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import { getSessionToken } from "@/lib/cookie.server";
import { CartApiResponse, CartItem } from "./types";


export async function getMyCartServer(): Promise<CartItem[]> {
    const token = await getSessionToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.CART}/me`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            ...(token ? { Authorization: `Bearer ${token}` } : {}),
        },
    });

    if (!res.ok) {
        if (res.status === 400 || res.status === 404) {
            return [];
        }
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Sepet bilgisi alınamadı");
    }

    const response: CartApiResponse = await res.json();
    return response.data;
}
