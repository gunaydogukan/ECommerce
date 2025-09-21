"use client";

import { useTransition, useMemo } from "react";
import { useRouter } from "next/navigation";
import { CartItem } from "@/services/cart/types";
import { Card, CardHeader, CardContent, CardFooter } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { PLACEHOLDER_IMAGE } from "@/lib/constants";
import { Minus, Plus, X } from "lucide-react";

import {
    updateCartServer,
    removeFromCartServer,
} from "@/services/cart/cart.server";

interface CartListProps {
    items: CartItem[];
}

export function CartList({ items }: CartListProps) {
    const [isPending, startTransition] = useTransition();
    const router = useRouter();

    console.log(items)
    const handleUpdateQuantity = (id: number, quantity: number) => {
        startTransition(async () => {
            if (quantity <= 0) {
                await removeFromCartServer(id);
            } else {
                await updateCartServer(id, quantity);
            }
            router.refresh();
        });
    };

    const handleRemove = (id: number) => {
        startTransition(async () => {
            await removeFromCartServer(id);
            router.refresh();
        });
    };

    const totalPrice = useMemo(
        () => items.reduce((sum, item) => sum + item.subtotal, 0),
        [items]
    );

    if (!items || items.length === 0) {
        return (
            <div className="text-center py-12 text-gray-500">
                Sepetiniz boş.
            </div>
        );
    }

    return (
        <div className="relative">
            {/* Ürünler */}
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-6 mb-24">
                {items.map((item) => (
                    <Card
                        key={item.id}
                        className="relative flex flex-col overflow-hidden group"
                    >
                        <CardHeader className="p-0 relative">
                            {/* Ürün resmi */}
                            <div className="relative h-32 w-full">
                                <img
                                    src={PLACEHOLDER_IMAGE}
                                    alt={item.productName}
                                    className="h-full w-full object-cover"
                                />
                            </div>

                            <button
                                onClick={() => handleRemove(item.id)}
                                disabled={isPending}
                                className="absolute top-2 right-2 flex items-center justify-center h-7 w-7 rounded-full bg-white/80 backdrop-blur border border-gray-200 text-gray-500 hover:bg-red-500 hover:text-white hover:border-red-500 shadow transition"
                            >
                                <X className="w-4 h-4" />
                            </button>
                        </CardHeader>

                        <CardContent className="p-4 flex-1 space-y-2">
                            <h3 className="text-base font-semibold line-clamp-1">
                                {item.productName}
                            </h3>
                            <p className="text-xs text-gray-500 line-clamp-2">
                                {"Açıklama bulunamadı"}
                            </p>
                            <div className="flex justify-between text-sm">
                                <span className="text-gray-600">Birim Fiyat:</span>
                                <span className="font-medium">{item.unitPrice} ₺</span>
                            </div>
                            <div className="flex justify-between text-sm">
                                <span className="text-gray-600">Adet:</span>
                                <span className="font-medium">{item.quantity}</span>
                            </div>
                            <div className="flex justify-between text-sm font-bold text-blue-600">
                                <span>Toplam:</span>
                                <span>{item.subtotal} ₺</span>
                            </div>
                        </CardContent>

                        <CardFooter className="flex items-center justify-center gap-2 p-3 border-t bg-gray-50">
                            <Button
                                size="icon"
                                variant="outline"
                                className="h-7 w-7"
                                disabled={isPending}
                                onClick={() => handleUpdateQuantity(item.id, item.quantity - 1)}
                            >
                                <Minus className="w-4 h-4" />
                            </Button>

                            <span className="min-w-[24px] text-center text-sm font-medium">
                                {item.quantity}
                            </span>

                            <Button
                                size="icon"
                                variant="outline"
                                className="h-7 w-7"
                                disabled={isPending}
                                onClick={() => handleUpdateQuantity(item.id, item.quantity + 1)}
                            >
                                <Plus className="w-4 h-4" />
                            </Button>
                        </CardFooter>
                    </Card>
                ))}
            </div>

            {/* Sepet Özeti (sticky bottom bar) */}
            <div className="fixed bottom-0 left-0 right-0 bg-white border-t shadow-md p-4 flex items-center justify-between">
                <div>
                    <p className="text-sm text-gray-500">Toplam Tutar</p>
                    <p className="text-xl font-bold text-blue-600">{totalPrice} ₺</p>
                </div>
                <Button
                    size="lg"
                    className="bg-blue-600 hover:bg-blue-700 text-white rounded-lg px-6"
                    onClick={() => alert("Ödeme sayfasına yönlendirilecek")}
                >
                    Hepsini Al
                </Button>
            </div>
        </div>
    );
}
