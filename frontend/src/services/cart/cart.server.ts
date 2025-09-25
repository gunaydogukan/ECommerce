"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import { getSessionToken } from "@/lib/cookie.server";
import {AddToCartApiResponse, AddToCartPayload, CartApiResponse, CartItem} from "./types";
import {cookies} from "next/headers";

export async function getMyCartServer(): Promise<CartItem[]> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.CART}/me`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
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

export async function addToCartServer(payload: AddToCartPayload): Promise<CartItem> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.CART}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        body: JSON.stringify(payload),
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Sepete ekleme başarısız");
    }

    const response: AddToCartApiResponse = await res.json();
    return response.data;
}

export async function updateCartServer(id: number, quantity: number): Promise<CartItem> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.CART}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        body: JSON.stringify({ cartId: id, quantity }),
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Sepet güncellenemedi");
    }

    const response: { data: CartItem } = await res.json();
    return response.data;
}

export async function removeFromCartServer(id: number): Promise<void> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.CART}/${id}`, {
        method: "DELETE",
        headers: {
            "Cookie": cookies().toString(),
        },
    });

    if (!res.ok) {
        if (res.status === 400 || res.status === 404) {
            return;
        }
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Sepet öğesi silinemedi");
    }
}