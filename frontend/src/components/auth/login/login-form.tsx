"use client";

import { useAtom } from "jotai";
import { isAuthenticatedAtom } from "@/stores/auth-atom";
import { useState } from "react";
import { useRouter } from "next/navigation";
import { ROUTES } from "@/lib/constants";
import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import Link from "next/link";
import { loginServer } from "@/services/auth/auth.server";

export default function LoginForm() {
    const router = useRouter();
    const [, setIsAuthenticated] = useAtom(isAuthenticatedAtom);

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [showPassword, setShowPassword] = useState(false);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        if (!email || !password) {
            setError("E-posta ve şifre zorunludur.");
            return;
        }

        try {
            setLoading(true);
            await loginServer({ email, password });
            setIsAuthenticated(true);

            router.push(ROUTES.HOME);

        } catch (err: any) {
            setError(err.message || "Giriş işlemi başarısız oldu.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <Card>
            <CardHeader className="px-6">
                <h1 className="text-2xl font-bold">Giriş Yap</h1>
                <p className="text-sm text-gray-600">
                    Hesabınıza erişmek için bilgilerinizi girin.
                </p>
            </CardHeader>

            <CardContent className="px-6">
                <form onSubmit={handleSubmit} className="space-y-4">
                    {error && (
                        <div className="rounded-md border border-red-200 bg-red-50 p-3 text-sm text-red-700">
                            {error}
                        </div>
                    )}

                    <div>
                        <label htmlFor="email" className="mb-1 block text-sm font-medium text-gray-700">
                            E-posta
                        </label>
                        <input
                            id="email"
                            type="email"
                            autoComplete="email"
                            className="w-full rounded-md border border-gray-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                            placeholder="ornek@mail.com"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            disabled={loading}
                        />
                    </div>

                    <div>
                        <label htmlFor="password" className="mb-1 block text-sm font-medium text-gray-700">
                            Şifre
                        </label>
                        <div className="relative">
                            <input
                                id="password"
                                type={showPassword ? "text" : "password"}
                                autoComplete="current-password"
                                className="w-full rounded-md border border-gray-300 px-3 py-2 pr-10 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                placeholder="••••••••"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                disabled={loading}
                            />
                            <button
                                type="button"
                                onClick={() => setShowPassword((s) => !s)}
                                className="absolute inset-y-0 right-2 my-auto text-sm text-gray-500 hover:text-gray-700"
                                aria-label={showPassword ? "Şifreyi gizle" : "Şifreyi göster"}
                            >
                                {showPassword ? "Gizle" : "Göster"}
                            </button>
                        </div>
                    </div>

                    <Button type="submit" disabled={loading} className="w-full">
                        {loading ? "Giriş yapılıyor..." : "Giriş Yap"}
                    </Button>
                </form>
            </CardContent>

            <CardFooter className="px-6 justify-between">
                <Link href="#" className="text-sm text-blue-600 hover:underline">
                    Şifremi unuttum
                </Link>
                <Link href="/auth/register" className="text-sm text-gray-700 hover:underline">
                    Hesabın yok mu? Kayıt ol
                </Link>
            </CardFooter>
        </Card>
    );
}