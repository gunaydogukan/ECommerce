"use server";

import { API_ENDPOINTS } from "@/lib/constants";
import { BASE_URL } from "@/lib/config";
import {
    LoginPayload,
    LoginResponse,
    RegisterPayload,
    RegisterResponse,
    LoginApiResponse,
    RegisterApiResponse,
} from "./types";
import { setSessionToken } from "@/lib/cookie.server";

export async function loginServer(payload: LoginPayload): Promise<LoginResponse> {
    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.AUTH}/auth/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Login failed");
    }

    const response: LoginApiResponse = await res.json();

    if (response?.data?.token) {
        await setSessionToken(response.data.token);
    }

    return response.data;
}

export async function registerServer(payload: RegisterPayload): Promise<RegisterResponse> {
    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.AUTH}/auth/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
        cache: "no-store",
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Register failed");
    }

    const response: RegisterApiResponse = await res.json();
    return response.data;
}
