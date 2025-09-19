"use client";

import { useMemo, useState } from "react";
import { Mail, Phone, User as UserIcon, Copy, Check, Edit } from "lucide-react";
import { Button } from "@/components/ui/button";
import { useUserProfile } from "@/hooks/use-user-profile";

function getInitials(first?: string, last?: string) {
    const f = (first || "").trim();
    const l = (last || "").trim();
    if (!f && !l) return "U";
    return `${f?.[0] ?? ""}${l?.[0] ?? ""}`.toUpperCase();
}

export default function ProfileCard() {
    const { user, loading, error } = useUserProfile();
    const [copied, setCopied] = useState<"email" | "phone" | null>(null);

    const fullName = useMemo(
        () => [user?.firstName, user?.lastName].filter(Boolean).join(" "),
        [user?.firstName, user?.lastName]
    );

    const initials = useMemo(
        () => getInitials(user?.firstName, user?.lastName),
        [user?.firstName, user?.lastName]
    );

    const copyToClipboard = async (text: string, key: "email" | "phone") => {
        try {
            await navigator.clipboard.writeText(text);
            setCopied(key);
            setTimeout(() => setCopied(null), 1500);
        } catch {
        }
    };

    if (loading) return (
        <div className="w-full max-w-2xl mx-auto">
            <div className="animate-pulse">
                <div className="bg-white rounded-xl shadow-lg p-8">
                    <div className="flex items-start gap-6 mb-8">
                        <div className="size-24 rounded-full bg-gray-200" />
                        <div className="flex-1 space-y-3">
                            <div className="h-8 bg-gray-200 rounded w-48" />
                            <div className="h-5 bg-gray-200 rounded w-32" />
                        </div>
                    </div>
                    <div className="space-y-6">
                        <div className="h-20 bg-gray-200 rounded-lg" />
                        <div className="h-20 bg-gray-200 rounded-lg" />
                    </div>
                </div>
            </div>
        </div>
    );

    if (error) return (
        <div className="w-full max-w-2xl mx-auto">
            <div className="text-center p-8 bg-red-50 rounded-xl border border-red-200">
                <p className="text-red-600 text-lg">{error}</p>
            </div>
        </div>
    );

    if (!user) return (
        <div className="w-full max-w-2xl mx-auto">
            <div className="text-center p-8 bg-gray-50 rounded-xl border">
                <p className="text-gray-600 text-lg">Kullanıcı bulunamadı.</p>
            </div>
        </div>
    );

    return (
        <div className="w-full max-w-2xl mx-auto">
            <div className="bg-white rounded-xl shadow-lg overflow-hidden border border-gray-100">
                {/* Header Section */}
                <div className="relative p-8 pb-6">
                    <div className="flex items-start justify-between mb-6">
                        <div className="flex items-start gap-6">
                            <div className="relative">
                                <div className="size-24 rounded-full overflow-hidden bg-gradient-to-br from-blue-500 to-purple-600 p-1">
                                    <div className="size-full rounded-full bg-white grid place-items-center">
                                        <span className="text-2xl font-bold text-gray-700">
                                            {initials}
                                        </span>
                                    </div>
                                </div>
                                <div className="absolute -bottom-1 -right-1 size-8 rounded-full bg-green-500 border-3 border-white grid place-items-center">
                                    <UserIcon className="size-4 text-white" />
                                </div>
                            </div>

                            <div className="flex-1 pt-2">
                                <h1 className="text-3xl font-bold text-gray-900 leading-tight mb-3">
                                    {fullName || "Kullanıcı"}
                                </h1>
                                <p className="text-gray-500 text-sm">
                                    Profil Bilgileri
                                </p>
                            </div>
                        </div>

                        <Button
                            size="sm"
                            className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2"
                        >
                            <Edit className="size-4 mr-2" />
                            Düzenle
                        </Button>
                    </div>
                </div>

                {/* Contact Information */}
                <div className="px-8 pb-8 space-y-6">
                    {/* Email Section */}
                    <div className="border rounded-lg p-5 hover:shadow-md transition-shadow">
                        <div className="flex items-center justify-between">
                            <div className="flex items-center gap-4 min-w-0 flex-1">
                                <div className="size-12 rounded-lg bg-blue-100 grid place-items-center flex-shrink-0">
                                    <Mail className="size-6 text-blue-600" />
                                </div>
                                <div className="min-w-0 flex-1">
                                    <p className="text-sm font-medium text-gray-500 mb-1">E-posta</p>
                                    <p className="text-lg font-semibold text-gray-900 truncate">
                                        {user.email}
                                    </p>
                                </div>
                            </div>
                            <div className="flex items-center gap-3 flex-shrink-0 ml-4">
                                <Button
                                    variant="outline"
                                    size="icon"
                                    className="size-9 border-gray-300"
                                    onClick={() => copyToClipboard(user.email, "email")}
                                    title="E-postayı kopyala"
                                >
                                    {copied === "email" ? (
                                        <Check className="size-4 text-green-600" />
                                    ) : (
                                        <Copy className="size-4 text-gray-600" />
                                    )}
                                </Button>
                                <Button 
                                    asChild 
                                    size="sm" 
                                    className="bg-blue-600 hover:bg-blue-700 text-white px-4"
                                >
                                    <a href={`mailto:${user.email}`}>E-posta Gönder</a>
                                </Button>
                            </div>
                        </div>
                    </div>

                    {/* Phone Section */}
                    <div className="border rounded-lg p-5 hover:shadow-md transition-shadow">
                        <div className="flex items-center justify-between">
                            <div className="flex items-center gap-4 min-w-0 flex-1">
                                <div className="size-12 rounded-lg bg-green-100 grid place-items-center flex-shrink-0">
                                    <Phone className="size-6 text-green-600" />
                                </div>
                                <div className="min-w-0 flex-1">
                                    <p className="text-sm font-medium text-gray-500 mb-1">Telefon</p>
                                    <p className="text-lg font-semibold text-gray-900">
                                        {user.phoneNumber || "Belirtilmedi"}
                                    </p>
                                </div>
                            </div>
                            {user.phoneNumber ? (
                                <div className="flex items-center gap-3 flex-shrink-0 ml-4">
                                    <Button
                                        variant="outline"
                                        size="icon"
                                        className="size-9 border-gray-300"
                                        onClick={() => copyToClipboard(user.phoneNumber, "phone")}
                                        title="Telefonu kopyala"
                                    >
                                        {copied === "phone" ? (
                                            <Check className="size-4 text-green-600" />
                                        ) : (
                                            <Copy className="size-4 text-gray-600" />
                                        )}
                                    </Button>
                                    <Button 
                                        asChild 
                                        size="sm" 
                                        variant="secondary"
                                        className="px-4 border-gray-300"
                                    >
                                        <a href={`tel:${user.phoneNumber}`}>Ara</a>
                                    </Button>
                                </div>
                            ) : (
                                <div className="text-gray-400 ml-4">—</div>
                            )}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}