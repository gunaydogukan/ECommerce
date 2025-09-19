"use client";

export function logout() {
    if (typeof window !== "undefined") {
        localStorage.removeItem("token");
    }
}

export function getAuthStatus(): boolean {
    if (typeof window === "undefined") return false;
    return !!localStorage.getItem("token");
}
