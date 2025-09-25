import { cookies } from "next/headers";

const TOKEN_KEY = "accessToken";

export async function getSessionToken(): Promise<string | undefined> {
    const cookie = await cookies();
    return cookie.get(TOKEN_KEY)?.value;
}

export async function clearSessionToken() {
    const cookie = await cookies();
    cookie.delete(TOKEN_KEY);
}
