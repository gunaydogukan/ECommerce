"use server";

import { getSessionToken,clearSessionToken } from "@/lib/cookie.server";

//silme islemi
export async function getCookieServer() {
    await clearSessionToken();
}

export async function getCookieToken(){
    return getSessionToken();
}
