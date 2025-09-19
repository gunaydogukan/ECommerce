"use client";

import { useMemo, useState } from "react";
import { Mail, Phone, User as UserIcon, Copy, Check } from "lucide-react";
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

    if (loading) return <p>Yükleniyor...</p>;
    if (error) return <p className="text-red-600">{error}</p>;
    if (!user) return <p>Kullanıcı bulunamadı.</p>;

    return (
        <div className="relative overflow-hidden rounded-2xl border bg-white shadow-sm">
            {/* Header gradient */}
            <div className="h-28 w-full bg-gradient-to-r from-blue-600 via-indigo-600 to-purple-600" />

            {/* Avatar + Name */}
            <div className="-mt-12 px-6 pb-6">
                <div className="flex items-end gap-4">
                    <div className="relative">
                        <div className="size-24 rounded-full ring-4 ring-white shadow-md overflow-hidden bg-white">
                            <div className="size-full grid place-items-center bg-gradient-to-br from-blue-50 to-indigo-50">
                <span className="text-2xl font-semibold text-indigo-700">
                  {initials}
                </span>
                            </div>
                        </div>
                        <div className="absolute -bottom-1 -right-1 grid size-7 place-items-center rounded-full bg-white ring-2 ring-white shadow">
                            <UserIcon className="size-4 text-indigo-600" />
                        </div>
                    </div>

                    <div className="flex-1">
                        <h1 className="text-xl md:text-2xl font-semibold text-gray-900 leading-tight">
                            {fullName || "Kullanıcı"}
                        </h1>
                        <a
                            href={`mailto:${user.email}`}
                            className="mt-1 inline-flex items-center gap-2 text-sm text-gray-600 hover:text-blue-600 transition-colors"
                        >
                            <Mail className="size-4" />
                            <span className="truncate">{user.email}</span>
                        </a>
                    </div>
                </div>

                {/* Info grid */}
                <div className="mt-6 grid grid-cols-1 md:grid-cols-2 gap-4">
                    {/* Email row */}
                    <div className="flex items-center justify-between rounded-xl border bg-gray-50 px-4 py-3">
                        <div className="flex items-center gap-3 min-w-0">
                            <div className="grid size-9 place-items-center rounded-lg bg-white border">
                                <Mail className="size-4 text-indigo-600" />
                            </div>
                            <div className="min-w-0">
                                <p className="text-xs text-gray-500">E-posta</p>
                                <p className="truncate text-sm font-medium text-gray-900">
                                    {user.email}
                                </p>
                            </div>
                        </div>
                        <Button
                            variant="outline"
                            size="icon"
                            className="ml-3 shrink-0"
                            onClick={() => copyToClipboard(user.email, "email")}
                            aria-label="E-postayı kopyala"
                            title="E-postayı kopyala"
                        >
                            {copied === "email" ? (
                                <Check className="size-4 text-green-600" />
                            ) : (
                                <Copy className="size-4" />
                            )}
                        </Button>
                    </div>

                    {/* Phone row */}
                    <div className="flex items-center justify-between rounded-xl border bg-gray-50 px-4 py-3">
                        <div className="flex items-center gap-3 min-w-0">
                            <div className="grid size-9 place-items-center rounded-lg bg-white border">
                                <Phone className="size-4 text-indigo-600" />
                            </div>
                            <div className="min-w-0">
                                <p className="text-xs text-gray-500">Telefon</p>
                                <p className="truncate text-sm font-medium text-gray-900">
                                    {user.phoneNumber || "Belirtilmedi"}
                                </p>
                            </div>
                        </div>
                        {user.phoneNumber ? (
                            <div className="flex items-center gap-2">
                                <Button
                                    variant="outline"
                                    size="icon"
                                    className="shrink-0"
                                    onClick={() => copyToClipboard(user.phoneNumber, "phone")}
                                    aria-label="Telefonu kopyala"
                                    title="Telefonu kopyala"
                                >
                                    {copied === "phone" ? (
                                        <Check className="size-4 text-green-600" />
                                    ) : (
                                        <Copy className="size-4" />
                                    )}
                                </Button>
                                <Button asChild size="sm" className="hidden md:inline-flex">
                                    <a href={`tel:${user.phoneNumber}`}>Ara</a>
                                </Button>
                            </div>
                        ) : (
                            <div className="text-xs text-gray-400">—</div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
}
