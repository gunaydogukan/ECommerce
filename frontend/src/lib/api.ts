"use server";

import { BASE_URL } from "@/lib/config";

interface ApiOptions extends RequestInit {
    authRequired?: boolean;
}

export async function apiFetch<T>(
    endpoint: string,
    options: ApiOptions = {}
): Promise<T> {
    const { authRequired = true, ...rest } = options;

    const res = await fetch(`${BASE_URL}${endpoint}`, {
        credentials: "include",
        headers: {
            "Content-Type": "application/json",
            ...(rest.headers || {}),
        },
        ...rest,
    });

    if (res.status === 401 && authRequired) {
        throw new Error("Yetkisiz erişim. Lütfen giriş yapınız.");
    }

    if (!res.ok) {
        let errorMessage = "İstek başarısız oldu";
        try {
            const err = await res.json();
            errorMessage = err?.message || errorMessage;
        } catch {
        }
        throw new Error(errorMessage);
    }

    if (res.status === 204) return {} as T;

    return (await res.json()) as T;
}
