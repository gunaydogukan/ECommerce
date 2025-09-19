"use client";

import { getToken } from "@/lib/auth.client";
import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import { GetMeApiResponse, UserProfile } from "./types";

export async function getMeClient(): Promise<UserProfile> {
    const token = getToken();
    if (!token) throw new Error("Token bulunamadı");

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.USERS}/me`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
        },
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Profil bilgileri alınamadı");
    }

    const response: GetMeApiResponse = await res.json();
    return response.data;
}
