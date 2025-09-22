"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import {Product, ProductsResponse, AddProductRequest,ProductResponse} from "./types";
import { getCookieToken } from "@/lib/getCookie.server";

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

export async function getMyProductsServer(): Promise<Product[]> {
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}/my`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
        },
        cache: "no-store",
    });

    if (!res.ok) {
        if (res.status === 400 || res.status === 404) {
            return [];
        }

        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Kendi ürünlerin getirilemedi");
    }

    const data: ProductsResponse = await res.json();
    return data.data;
}

export async function addProductServer(payload: AddProductRequest): Promise<Product> {
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(payload),
    });

    if (!res.ok) {
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Ürün eklenemedi");
    }

    const data: ProductResponse = await res.json();
    return data.data;
}

export async function updateProductServer(id: number, payload: Partial<Product>): Promise<Product> {
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({ ...payload, id }),
    });
    console.log(payload)
    if (!res.ok) {
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Ürün güncellenemedi");
    }

    const data: ProductResponse = await res.json();
    return data.data;
}

export async function getProductByIdServer(id: number): Promise<Product | null> {
    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}/${id}`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
        cache: "no-store",
    });

    if (!res.ok) {
        if (res.status === 404) return null;
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Ürün getirilemedi");
    }

    const data: ProductResponse = await res.json();
    return data.data;
}

export async function getProductsByCategoryServer(categoryId: number): Promise<Product[]> {
    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}/by-category/${categoryId}`, {
        method: "GET",
        headers: { "Content-Type": "application/json" },
        cache: "no-store",
    });

    if (!res.ok) {
        if (res.status === 404) return [];
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Kategoriye göre ürünler getirilemedi");
    }

    const data: ProductsResponse = await res.json();
    return data.data;
}

export async function deleteProductServer(id: number): Promise<void> {
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.PRODUCTS}/${id}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
        },
    });

    if (!res.ok) {
        const err = await res.json().catch(() => ({}));
        throw new Error(err?.message || "Ürün silinemedi");
    }
}
