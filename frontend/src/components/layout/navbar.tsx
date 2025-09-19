"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";
import { ROUTES } from "@/lib/constants";
import { useAuth } from "@/hooks/use-auth";

export function Navbar() {
    const router = useRouter();
    const { isAuthenticated, logout } = useAuth();

    const handleLogout = () => {
        logout();
        router.push(ROUTES.HOME);
    };

    return (
        <nav className="w-full border-b bg-white shadow-sm">
            <div className="flex items-center justify-between px-4 py-3 md:px-6 lg:px-8 xl:px-12 2xl:px-16">
                {/* Logo */}
                <Link href={ROUTES.HOME} className="text-lg md:text-xl font-bold text-blue-600">
                    apptotech ecommerce
                </Link>

                {/* Menu */}
                <div className="flex items-center space-x-2 md:space-x-6">
                    <Link href={ROUTES.PRODUCTS} className="text-sm md:text-base text-gray-700 hover:text-blue-600 transition-colors">
                        Ürünler
                    </Link>
                    <Link href={ROUTES.ABOUT} className="text-sm md:text-base text-gray-700 hover:text-blue-600 transition-colors">
                        Hakkımızda
                    </Link>
                    <Link href={ROUTES.CONTACT} className="text-sm md:text-base text-gray-700 hover:text-blue-600 transition-colors">
                        İletişim
                    </Link>
                </div>

                {/* Actions - Conditional based on auth status */}
                <div className="flex items-center space-x-2 md:space-x-3">
                    {isAuthenticated  ? (
                        <Button
                            variant="outline"
                            size="sm"
                            className="text-xs md:text-sm px-2 md:px-4"
                            onClick={handleLogout}
                        >
                            Çıkış Yap
                        </Button>
                    ) : (
                        <>
                            <Button variant="outline" size="sm" className="text-xs md:text-sm px-2 md:px-4" asChild>
                                <Link href={ROUTES.LOGIN}>Giriş Yap</Link>
                            </Button>
                            <Button size="sm" className="text-xs md:text-sm px-2 md:px-4" asChild>
                                <Link href="/auth/register">Kayıt Ol</Link>
                            </Button>
                        </>
                    )}
                </div>
            </div>
        </nav>
    );
}
