"use server";

import { API_ENDPOINTS } from "@/lib/constants";
import { BASE_URL } from "@/lib/config";
import { GetMeApiResponse, UserProfile } from "./types";
//import { getToken } from "@/lib/auth.client";

export async function getMeServer(): Promise<UserProfile> {
    //const token = getToken();

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.USERS}/me`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            //...(token ? { Authorization: `Bearer ${token}` } : {}),
        },
        cache: "no-store",
    });
    console.log(res);
    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Profil bilgileri alınamadı");
    }

    const response: GetMeApiResponse = await res.json();
    return response.data;
}
