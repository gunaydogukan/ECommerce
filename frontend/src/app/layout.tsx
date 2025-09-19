import "./globals.css";
import type {Metadata} from "next";
import {Navbar} from "@/components/layout/navbar";
//import {Provider} from 'jotai';
import {AuthProvider} from "@/context/AuthContext";

export const metadata: Metadata = {
    title: "E-Commerce App",
    description: "Modern e-commerce application",
};

export default function RootLayout({children,}: { children: React.ReactNode; })
{
    return (
        <html lang="en">
        <body className={`antialiased`}>
        <AuthProvider>
            <Navbar/>
            {children}
        </AuthProvider>
        </body>
        </html>
    );
}