"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import {CreateOrderApiResponse, CreateOrderPayload, GetMyOrdersApiResponse} from "@/services/order/types";
import { getCookieToken } from "@/lib/getCookie.server";

export async function createOrderServer(payload: CreateOrderPayload): Promise<CreateOrderApiResponse> {
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.ORDERS}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            ...(token ? { Authorization: `Bearer ${token}` } : {}),
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
    const token = await getCookieToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.ORDERS}/my`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            ...(token ? { Authorization: `Bearer ${token}` } : {}),
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