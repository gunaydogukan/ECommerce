"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import { ROUTES } from "@/lib/constants";
import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import Link from "next/link";
import { registerServer } from "@/services/auth/auth.server";

export default function RegisterForm() {
    const router = useRouter();
    const [formData, setFormData] = useState({
        email: "",
        firstName: "",
        lastName: "",
        password: "",
        phoneNumber: "",
        confirmPassword: "",
    });
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData((prev) => ({ ...prev, [name]: value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        try {
            setLoading(true);
            const { confirmPassword, ...registerData } = formData;
            await registerServer(registerData);

            router.push(
                ROUTES.LOGIN + "?message=Kayıt başarılı! Şimdi giriş yapabilirsiniz."
            );
        } catch (err: any) {
            setError(err.message || "Kayıt işlemi başarısız oldu.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <Card>
            <CardHeader className="px-6">
                <h1 className="text-2xl font-bold">Kayıt Ol</h1>
                <p className="text-sm text-gray-600">
                    Yeni hesap oluşturmak için bilgilerinizi girin.
                </p>
            </CardHeader>

            <CardContent className="px-6">
                <form onSubmit={handleSubmit} className="space-y-4">
                    {error && (
                        <div className="rounded-md border border-red-200 bg-red-50 p-3 text-sm text-red-700">
                            {error}
                        </div>
                    )}

                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="firstName" className="mb-1 block text-sm font-medium text-gray-700">
                                Ad
                            </label>
                            <input
                                id="firstName"
                                name="firstName"
                                type="text"
                                value={formData.firstName}
                                onChange={handleInputChange}
                                disabled={loading}
                                className="w-full rounded-md border px-3 py-2 text-sm"
                            />
                        </div>
                        <div>
                            <label htmlFor="lastName" className="mb-1 block text-sm font-medium text-gray-700">
                                Soyad
                            </label>
                            <input
                                id="lastName"
                                name="lastName"
                                type="text"
                                value={formData.lastName}
                                onChange={handleInputChange}
                                disabled={loading}
                                className="w-full rounded-md border px-3 py-2 text-sm"
                            />
                        </div>
                    </div>

                    <div>
                        <label htmlFor="email" className="mb-1 block text-sm font-medium text-gray-700">
                            E-posta
                        </label>
                        <input
                            id="email"
                            name="email"
                            type="email"
                            value={formData.email}
                            onChange={handleInputChange}
                            disabled={loading}
                            className="w-full rounded-md border px-3 py-2 text-sm"
                        />
                    </div>

                    <div>
                        <label htmlFor="phoneNumber" className="mb-1 block text-sm font-medium text-gray-700">
                            Telefon Numarası
                        </label>
                        <input
                            id="phoneNumber"
                            name="phoneNumber"
                            type="tel"
                            value={formData.phoneNumber}
                            onChange={handleInputChange}
                            disabled={loading}
                            className="w-full rounded-md border px-3 py-2 text-sm"
                        />
                    </div>

                    <div>
                        <label htmlFor="password" className="mb-1 block text-sm font-medium text-gray-700">
                            Şifre
                        </label>
                        <div className="relative">
                            <input
                                id="password"
                                name="password"
                                type={showPassword ? "text" : "password"}
                                value={formData.password}
                                onChange={handleInputChange}
                                disabled={loading}
                                className="w-full rounded-md border px-3 py-2 pr-10 text-sm"
                            />
                            <button
                                type="button"
                                onClick={() => setShowPassword((s) => !s)}
                                className="absolute inset-y-0 right-2 my-auto text-sm text-gray-500 hover:text-gray-700"
                            >
                                {showPassword ? "Gizle" : "Göster"}
                            </button>
                        </div>
                    </div>

                    <div>
                        <label htmlFor="confirmPassword" className="mb-1 block text-sm font-medium text-gray-700">
                            Şifre Tekrar
                        </label>
                        <div className="relative">
                            <input
                                id="confirmPassword"
                                name="confirmPassword"
                                type={showConfirmPassword ? "text" : "password"}
                                value={formData.confirmPassword}
                                onChange={handleInputChange}
                                disabled={loading}
                                className="w-full rounded-md border px-3 py-2 pr-10 text-sm"
                            />
                            <button
                                type="button"
                                onClick={() => setShowConfirmPassword((s) => !s)}
                                className="absolute inset-y-0 right-2 my-auto text-sm text-gray-500 hover:text-gray-700"
                            >
                                {showConfirmPassword ? "Gizle" : "Göster"}
                            </button>
                        </div>
                    </div>

                    <Button type="submit" disabled={loading} className="w-full">
                        {loading ? "Kayıt yapılıyor..." : "Kayıt Ol"}
                    </Button>
                </form>
            </CardContent>

            <CardFooter className="px-6 justify-center">
                <Link href={ROUTES.LOGIN} className="text-sm text-gray-700 hover:underline">
                    Zaten hesabın var mı? Giriş yap
                </Link>
            </CardFooter>
        </Card>
    );
}
