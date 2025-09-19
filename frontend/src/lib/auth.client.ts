"use client";

export function setToken(token: string) {
    if (typeof window !== "undefined") {
        localStorage.setItem("token", token);
    }
}

export function getToken(): string | null {
    if (typeof window === "undefined") return null;
    return localStorage.getItem("token");
}

export function getAuthStatus(): boolean {
    if (typeof window === "undefined") return false;
    return !!localStorage.getItem("token");
}

export function logout() {
    if (typeof window !== "undefined") {
        localStorage.removeItem("token");
    }
}

