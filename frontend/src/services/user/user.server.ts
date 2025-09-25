"use server";

import { BASE_URL } from "@/lib/config";
import { API_ENDPOINTS } from "@/lib/constants";
import { GetMeApiResponse, UserProfile } from "./types";
import {cookies} from "next/headers";

export async function getMeServer(): Promise<UserProfile> {

    const res = await fetch(`${BASE_URL}${API_ENDPOINTS.USERS}/me`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Cookie": cookies().toString(),
        },
    });

    if (!res.ok) {
        const error = await res.json().catch(() => ({}));
        throw new Error(error?.message || "Profil bilgileri alınamadı");
    }

    const response: GetMeApiResponse = await res.json();
    return response.data;
}
