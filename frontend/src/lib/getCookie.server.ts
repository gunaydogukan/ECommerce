"use server";

import { getSessionToken,clearSessionToken } from "@/lib/cookie.server";

export async function getCookieServer() {
    await clearSessionToken();
}

export async function getCookieToken(){
    return getSessionToken();
}
