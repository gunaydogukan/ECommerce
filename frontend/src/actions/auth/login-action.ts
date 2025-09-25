"use server"
import { loginServer } from "@/services/auth/auth.server";
import {cookies} from "next/headers";

export const loginAction = async (email:string,password:string) => {
    const res = await loginServer({ email, password });

    const setCookie = res.headers.get("set-cookie");

    if (setCookie) {
        const tokenMatch = setCookie.match(/accessToken=([^;]+);/);
        if (tokenMatch) {
            const cookieStore = await cookies();
            cookieStore.set("accessToken", tokenMatch[1], {
                httpOnly: true,
                secure: true,
                path: "/",
                maxAge: 60 * 60 * 24,
            });
        }
    }

    const data = await res.json();
    return data;
}