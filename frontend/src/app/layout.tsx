import "./globals.css";
import type { Metadata } from "next";
import { Navbar } from "@/components/layout/navbar";
import Providers from "@/context/providers";
import { getSessionToken } from "@/lib/cookie.server";

export const metadata: Metadata = {
    title: "E-Commerce App",
    description: "Modern e-commerce application",
};

export default async function RootLayout({ children }: { children: React.ReactNode }) {
    const token = await getSessionToken();

    return (
        <html lang="en">
        <body className="antialiased">
        <Providers initialAuth={!!token}>
            <Navbar />
            {children}
        </Providers>
        </body>
        </html>
    );
}
