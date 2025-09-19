import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { PUBLIC_ROUTES, AUTH_ROUTES, PROTECTED_ROUTES } from "@/lib/auth-guard.config";

function matchesRoute(pathname: string, routes: string[]) {
    return routes.some((r) =>
        r === "/"
            ? pathname === "/"
            : pathname === r || pathname.startsWith(`${r}/`)
    );
}

export function middleware(request: NextRequest) {
    const token = request.cookies.get("token")?.value;
    const { pathname } = request.nextUrl;

    console.log("token:", token, "pathname:", pathname);

    // Public
    if (matchesRoute(pathname, PUBLIC_ROUTES)) {
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

    return NextResponse.next();
}

export const config = {
    matcher: [
        "/auth/:path*",
        "/profile/:path*",
        "/orders/:path*",
        "/cart/:path*",
        "/admin/:path*",
    ],
};
