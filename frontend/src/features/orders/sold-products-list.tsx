"use client";

import { SoldProductResponse } from "@/services/order/types";

interface Props {
    products: SoldProductResponse[];
}

export default function SoldProductsList({ products }: Props) {
    if (!products || products.length === 0) {
        return (
            <div className="text-center py-12 text-gray-500">
                Henüz satılan ürün yok.
            </div>
        );
    }

    const totalRevenue = products.reduce((sum, p) => sum + p.totalRevenue, 0);
    console.log(products);

    return (
        <div className="space-y-6">
            {/* ✅ Genel toplam kazanç kutusu */}
            <div className="border rounded-lg p-6 bg-blue-50 shadow-sm">
                <h2 className="text-lg font-semibold text-blue-700">Toplam Kazanç</h2>
                <p className="text-2xl font-bold text-blue-600">
                    {totalRevenue.toLocaleString("tr-TR")} ₺
                </p>
            </div>

            {/* ✅ Satılan ürünler listesi */}
            {products.map((p) => (
                <div
                    key={p.productId}
                    className="border rounded-lg p-6 bg-white shadow-sm"
                >
                    <div className="flex justify-between items-center mb-4">
                        <h2 className="text-lg font-semibold">{p.productName}</h2>
                        <div className="text-sm text-gray-500">
                            {p.totalQuantity} adet · {p.totalRevenue.toLocaleString("tr-TR")} ₺
                        </div>
                    </div>

                    <details className="text-sm text-gray-600">
                        <summary className="cursor-pointer font-medium mb-2">
                            Detayları Gör
                        </summary>
                        <div className="space-y-1 mt-2">
                            {p.sales.map((s, i) => (
                                <div
                                    key={`${p.productId}-${s.orderId}-${i}`}
                                    className="flex justify-between border-b py-1"
                                >
                  <span>
                    {s.buyerEmail} · {s.quantity} x {s.unitPrice} ₺
                  </span>
                                    <span>{s.subtotal.toLocaleString("tr-TR")} ₺</span>
                                </div>
                            ))}
                        </div>
                    </details>
                </div>
            ))}
        </div>
    );
}
