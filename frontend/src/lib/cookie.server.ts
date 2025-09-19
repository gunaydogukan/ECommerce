import { cookies } from "next/headers";

const TOKEN_KEY = "token";

export async function setSessionToken(token: string) {
    const cookie = await cookies();
    cookie.set(TOKEN_KEY, token, {
        httpOnly: true,
        secure: process.env.NODE_ENV === "production",
        sameSite: "lax",
        path: "/",
        maxAge: 60 * 60 * 24,
    });
}

export async function getSessionToken(): Promise<string | undefined> {
    const cookie = await cookies();
    return cookie.get(TOKEN_KEY)?.value;
}

export async function clearSessionToken() {
    const cookie = await cookies();
    cookie.delete(TOKEN_KEY);
}
