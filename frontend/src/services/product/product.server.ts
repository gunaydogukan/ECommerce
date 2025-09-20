"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import type { Product, ProductsResponse } from "./types";

export async function getProductsServer(): Promise<Product[]> {
    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    });

    if (!res.ok) {
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Ürünler yüklenemedi");
    }

    const data: ProductsResponse = await res.json();
    return data.data;
}