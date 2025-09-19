"use client";

import {useState} from "react";
import {useRouter} from "next/navigation";
import {register} from "@/services/authService";
import {GuestOnly} from "@/components/auth/guest-only";
import {ROUTES} from "@/lib/constants";
import {Card, CardContent, CardFooter, CardHeader} from "@/components/ui/card";
import {Button} from "@/components/ui/button";
import Link from "next/link";

export default function RegisterPage() {
    const router = useRouter();
    const [formData, setFormData] = useState({
        email: "",
        firstName: "",
        lastName: "",
        password: "",
        phoneNumber: "",
        confirmPassword: ""
    });
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmPassword, setShowConfirmPassword] = useState(false);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const {name, value} = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: value
        }));
    };

    const validateForm = () => {
        const {email, firstName, lastName, password, phoneNumber, confirmPassword} = formData;

        if (!email || !firstName || !lastName || !password || !phoneNumber) {
            setError("Tüm alanlar zorunludur.");
            return false;
        }

        if (password.length < 6) {
            setError("Şifre en az 6 karakter olmalıdır.");
            return false;
        }

        if (password !== confirmPassword) {
            setError("Şifreler eşleşmiyor.");
            return false;
        }

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            setError("Geçerli bir e-posta adresi girin.");
            return false;
        }

        const phoneRegex = /^[0-9]{11}$/;
        if (!phoneRegex.test(phoneNumber.replace(/\s/g, ""))) {
            setError("Geçerli bir telefon numarası girin (11 haneli).");
            return false;
        }

        return true;
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        if (!validateForm()) {
            return;
        }

        try {
            setLoading(true);
            const {confirmPassword, ...registerData} = formData;
            await register(registerData);

            // Başarılı kayıt mesajı göster ve login sayfasına yönlendir
            router.push(ROUTES.LOGIN + '?message=Kayıt başarılı! Şimdi giriş yapabilirsiniz.');

        } catch (err: any) {
            const msg =
                err?.response?.data?.message ||
                err?.message || "Kayıt işlemi başarısız oldu.";
            setError(msg);

        } finally {
            setLoading(false);
        }
    };

    return (
        <GuestOnly>
            <div className="mx-auto max-w-md py-10">
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
                                    <label
                                        htmlFor="firstName"
                                        className="mb-1 block text-sm font-medium text-gray-700"
                                    >
                                        Ad
                                    </label>
                                    <input
                                        id="firstName"
                                        name="firstName"
                                        type="text"
                                        autoComplete="given-name"
                                        className="w-full rounded-md border border-gray-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        placeholder="Adınız"
                                        value={formData.firstName}
                                        onChange={handleInputChange}
                                        disabled={loading}
                                    />
                                </div>

                                <div>
                                    <label
                                        htmlFor="lastName"
                                        className="mb-1 block text-sm font-medium text-gray-700"
                                    >
                                        Soyad
                                    </label>
                                    <input
                                        id="lastName"
                                        name="lastName"
                                        type="text"
                                        autoComplete="family-name"
                                        className="w-full rounded-md border border-gray-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        placeholder="Soyadınız"
                                        value={formData.lastName}
                                        onChange={handleInputChange}
                                        disabled={loading}
                                    />
                                </div>
                            </div>

                            <div>
                                <label
                                    htmlFor="email"
                                    className="mb-1 block text-sm font-medium text-gray-700"
                                >
                                    E-posta
                                </label>
                                <input
                                    id="email"
                                    name="email"
                                    type="email"
                                    autoComplete="email"
                                    className="w-full rounded-md border border-gray-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="ornek@mail.com"
                                    value={formData.email}
                                    onChange={handleInputChange}
                                    disabled={loading}
                                />
                            </div>

                            <div>
                                <label
                                    htmlFor="phoneNumber"
                                    className="mb-1 block text-sm font-medium text-gray-700"
                                >
                                    Telefon Numarası
                                </label>
                                <input
                                    id="phoneNumber"
                                    name="phoneNumber"
                                    type="tel"
                                    autoComplete="tel"
                                    className="w-full rounded-md border border-gray-300 px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="05551234567"
                                    value={formData.phoneNumber}
                                    onChange={handleInputChange}
                                    disabled={loading}
                                />
                            </div>

                            <div>
                                <label
                                    htmlFor="password"
                                    className="mb-1 block text-sm font-medium text-gray-700"
                                >
                                    Şifre
                                </label>
                                <div className="relative">
                                    <input
                                        id="password"
                                        name="password"
                                        type={showPassword ? "text" : "password"}
                                        autoComplete="new-password"
                                        className="w-full rounded-md border border-gray-300 px-3 py-2 pr-10 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        placeholder="••••••••"
                                        value={formData.password}
                                        onChange={handleInputChange}
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

                            <div>
                                <label
                                    htmlFor="confirmPassword"
                                    className="mb-1 block text-sm font-medium text-gray-700"
                                >
                                    Şifre Tekrar
                                </label>
                                <div className="relative">
                                    <input
                                        id="confirmPassword"
                                        name="confirmPassword"
                                        type={showConfirmPassword ? "text" : "password"}
                                        autoComplete="new-password"
                                        className="w-full rounded-md border border-gray-300 px-3 py-2 pr-10 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
                                        placeholder="••••••••"
                                        value={formData.confirmPassword}
                                        onChange={handleInputChange}
                                        disabled={loading}
                                    />
                                    <button
                                        type="button"
                                        onClick={() => setShowConfirmPassword((s) => !s)}
                                        className="absolute inset-y-0 right-2 my-auto text-sm text-gray-500 hover:text-gray-700"
                                        aria-label={showConfirmPassword ? "Şifreyi gizle" : "Şifreyi göster"}
                                    >
                                        {showConfirmPassword ? "Gizle" : "Göster"}
                                    </button>
                                </div>
                            </div>

                            <Button
                                type="submit"
                                disabled={loading}
                                className="w-full"
                            >
                                {loading ? "Kayıt yapılıyor..." : "Kayıt Ol"}
                            </Button>
                        </form>
                    </CardContent>

                    <CardFooter className="px-6 justify-center">
                        <Link
                            href="/auth/login"
                            className="text-sm text-gray-700 hover:underline"
                        >
                            Zaten hesabın var mı? Giriş yap
                        </Link>
                    </CardFooter>
                </Card>
            </div>
        </GuestOnly>
    );
}
