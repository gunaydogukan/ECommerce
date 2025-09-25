"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import {
    CreateOrderApiResponse,
    CreateOrderPayload,
    GetMyOrdersApiResponse,
    GetSoldProductsApiResponse
} from "@/services/order/types";
import { getCookieToken } from "@/lib/getCookie.server";
import {cookies} from "next/headers";

export async function createOrderServer(payload: CreateOrderPayload): Promise<CreateOrderApiResponse> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.ORDERS}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        body: JSON.stringify(payload),
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Sipariş oluşturulamadı");
    }

    const data: CreateOrderApiResponse = await res.json();
    return data;
}

export async function getMyOrdersServer(): Promise<GetMyOrdersApiResponse> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.ORDERS}/my`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Siparişler getirilemedi");
    }

    const data: GetMyOrdersApiResponse = await res.json();
    return data;
}

export async function getSoldProductsServer(): Promise<GetSoldProductsApiResponse> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.ORDERS}/sold-products`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Satılan ürünler getirilemedi");
    }

    return await res.json();
}