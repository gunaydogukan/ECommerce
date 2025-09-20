"use client";

import { CartItem } from "@/services/cart/types";
import { Card, CardHeader, CardContent, CardFooter } from "@/components/ui/card";
import { Button } from "@/components/ui/button";

interface CartListProps {
    items: CartItem[];
}

export function CartList({ items }: CartListProps) {
    if (!items || items.length === 0) {
        return (
            <div className="text-center py-12 text-gray-500">
                Sepetiniz boş.
            </div>
        );
    }

    return (
        <div className="space-y-4">
            {items.map((item) => (
                <Card key={item.id} className="overflow-hidden">
                    <CardHeader className="flex flex-row items-center justify-between pb-2">
                        <h3 className="font-semibold">{item.productName}</h3>
                        <span className="text-sm text-gray-500">
              {item.quantity} × {item.unitPrice} ₺
            </span>
                    </CardHeader>

                    <CardContent>
                        <p className="text-sm text-gray-600">
                            Toplam:{" "}
                            <span className="font-bold text-blue-600">
                {item.subtotal} ₺
              </span>
                        </p>
                    </CardContent>

                    <CardFooter className="flex justify-end gap-2">
                        <Button size="sm" variant="outline">
                            Güncelle
                        </Button>
                        <Button size="sm" variant="destructive">
                            Kaldır
                        </Button>
                    </CardFooter>
                </Card>
            ))}
        </div>
    );
}
