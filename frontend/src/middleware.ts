import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { PUBLIC_ROUTES, AUTH_ROUTES, PROTECTED_ROUTES } from "@/lib/auth-guard.config";

function matchesRoute(pathname: string, routes: string[], exact: boolean = false) {
    return routes.some((r) =>
        r === "/"
            ? pathname === "/"
            : exact
                ? pathname === r
                : pathname === r || pathname.startsWith(`${r}/`)
    );
}

export function middleware(request: NextRequest) {
    const token = request.cookies.get("token")?.value;
    const { pathname } = request.nextUrl;

    if (matchesRoute(pathname, PUBLIC_ROUTES, true)) {
        return NextResponse.next();
    }

    if (matchesRoute(pathname, AUTH_ROUTES)) {
        if (token) {
            return NextResponse.redirect(new URL("/", request.url));
        }
        return NextResponse.next();
    }

    if (matchesRoute(pathname, PROTECTED_ROUTES)) {
        if (!token) {
            return NextResponse.redirect(new URL("/auth/login", request.url));
        }
        return NextResponse.next();
    }

    if (/^\/products\/\d+\/edit$/.test(pathname)) {
        if (!token) {
            return NextResponse.redirect(new URL("/auth/login", request.url));
        }
    }

    return NextResponse.next();
}

export const config = {
    matcher: ["/:path*"],
};
