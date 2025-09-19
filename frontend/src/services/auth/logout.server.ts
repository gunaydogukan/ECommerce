"use server";

import { clearSessionToken } from "@/lib/cookie.server";

export async function logoutServer() {
    await clearSessionToken();
}
