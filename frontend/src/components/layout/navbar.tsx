"use client";

import Link from "next/link";
import { Button } from "@/components/ui/button";
import { ROUTES } from "@/lib/constants";
import {User as UserIcon, ShoppingCart, Heart} from "lucide-react";
import {
    NavigationMenu,
    NavigationMenuList,
    NavigationMenuItem,
    NavigationMenuTrigger,
    NavigationMenuContent,
    NavigationMenuLink,
} from "@/components/ui/navigation-menu";
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuTrigger,
    DropdownMenuSeparator,
} from "@/components/ui/dropdown-menu";
import {isAuthenticatedAtom} from "@/stores/auth-atom";
import {useAtom} from "jotai";
import {getCookieServer} from "@/lib/getCookie.server";
import {router} from "next/client";
import {categories} from "@/types";

export function Navbar() {
    const [isAuthenticated, setIsAuthenticated] = useAtom(isAuthenticatedAtom);

    const logout = async () => {
        await getCookieServer();
        setIsAuthenticated(false);
        await router.push("/auth/login");
    };

    return (
        <nav className="w-full border-b bg-white shadow-sm">
            <div className="flex items-center justify-between px-6 py-3">
                {/* Logo */}
                <Link
                    href={ROUTES.HOME}
                    className="text-lg md:text-xl font-bold text-blue-600"
                >
                    apptotech ecommerce
                </Link>

                <NavigationMenu>
                    <NavigationMenuList>
                        <NavigationMenuItem>
                            <NavigationMenuTrigger>Ürünler</NavigationMenuTrigger>
                            <NavigationMenuContent className="p-4">
                                <div className="grid gap-3 w-[200px]">
                                    <div className="grid gap-3 w-[200px]">
                                        {categories.map((cat) => (
                                            <NavigationMenuLink asChild key={cat.id}>
                                                <Link
                                                    href={{
                                                        pathname: ROUTES.PRODUCTS,
                                                        query: { category: cat.id },
                                                    }}
                                                    className="block"
                                                >
                                                    {cat.name}
                                                </Link>
                                            </NavigationMenuLink>
                                        ))}
                                    </div>
                                </div>
                            </NavigationMenuContent>
                        </NavigationMenuItem>

                        <NavigationMenuItem>
                            <NavigationMenuLink asChild>
                                <Link href={ROUTES.ABOUT}>Hakkımızda</Link>
                            </NavigationMenuLink>
                        </NavigationMenuItem>

                        <NavigationMenuItem>
                            <NavigationMenuLink asChild>
                                <Link href={ROUTES.CONTACT}>İletişim</Link>
                            </NavigationMenuLink>
                        </NavigationMenuItem>
                    </NavigationMenuList>
                </NavigationMenu>

                <div className="flex items-center gap-4">
                    {isAuthenticated ? (
                        <>
                            <Link href={ROUTES.FAVORITES}>
                                <Heart className="w-5 h-5 text-gray-700 hover:text-red-500" />
                            </Link>

                            <Link href={ROUTES.CART}>
                                <ShoppingCart className="w-5 h-5 text-gray-700 hover:text-blue-600" />
                            </Link>

                            <DropdownMenu>
                                <DropdownMenuTrigger asChild>
                                    <Button
                                        variant="ghost"
                                        size="sm"
                                        className="inline-flex items-center gap-2"
                                    >
                                        <UserIcon className="w-4 h-4" />
                                        Hesap
                                    </Button>
                                </DropdownMenuTrigger>
                                <DropdownMenuContent align="end" className="w-48">
                                    <DropdownMenuItem asChild>
                                        <Link href={ROUTES.PROFILE}>Profilim</Link>
                                    </DropdownMenuItem>
                                    <DropdownMenuItem asChild>
                                        <Link href="/products/my">Ürünlerim</Link>
                                    </DropdownMenuItem>
                                    <DropdownMenuItem asChild>
                                        <Link href="/products/add">Ürün Ekle</Link>
                                    </DropdownMenuItem>
                                    <DropdownMenuItem asChild>
                                        <Link href={ROUTES.ORDERS}>Siparişlerim</Link>
                                    </DropdownMenuItem>
                                    <DropdownMenuItem asChild>
                                        <Link href={ROUTES.SOLD}>Satış Yaptıklarım</Link>
                                    </DropdownMenuItem>
                                    <DropdownMenuSeparator />
                                    <DropdownMenuItem onClick={logout}>Çıkış Yap</DropdownMenuItem>
                                </DropdownMenuContent>

                            </DropdownMenu>
                        </>
                    ) : (
                        <>
                            <Button variant="outline" size="sm" asChild>
                                <Link href={ROUTES.LOGIN}>Giriş Yap</Link>
                            </Button>
                            <Button size="sm" asChild>
                                <Link href={ROUTES.REGISTER}>Kayıt Ol</Link>
                            </Button>
                        </>
                    )}
                </div>
            </div>
        </nav>
    );
}
