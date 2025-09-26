"use client";

import {OrderResponse} from "@/services/order/types";

interface OrdersListProps {
    orders: OrderResponse[];
}

export default function OrdersList({orders}: OrdersListProps) {
    if (!orders || orders.length === 0) {
        return (
            <div className="text-center py-12 text-gray-500">
                Henüz siparişiniz bulunmamaktadır.
            </div>
        );
    }

    const totalSpent = orders.reduce((sum, order) => sum + order.totalAmount, 0);

    return (
        <div className="space-y-6">
            <div className="border rounded-lg p-6 bg-green-50 shadow-sm">
                <h2 className="text-lg font-semibold text-green-700">Toplam Harcama</h2>
                <p className="text-2xl font-bold text-green-600">
                    {totalSpent.toLocaleString("tr-TR")} ₺
                </p>
            </div>

            {orders.map((order) => (
                <div
                    key={order.id}
                    className="border rounded-lg p-6 bg-white shadow-sm"
                >
                    <div className="flex justify-between items-center mb-4">
                        <h2 className="text-lg font-semibold">
                            Sipariş #{order.id}
                        </h2>
                        <span
                            className="text-sm text-gray-500">{new Date(order.createdAt).toLocaleDateString("tr-TR")}</span>
                    </div>

                    <div className="text-sm text-gray-600 mb-2">
                        Durum: <span className="font-medium">{order.status}</span>
                    </div>

                    <div className="space-y-2">
                        {order.orderItems.map((item) => (
                            <div
                                key={item.productId}
                                className="flex justify-between text-sm"
                            >
                                <span>{item.productName} x {item.quantity}</span>
                                <span>{item.subtotal.toLocaleString("tr-TR")} ₺</span>
                            </div>
                        ))}
                    </div>

                    <div className="flex justify-between border-t mt-4 pt-2 font-bold text-blue-600">
                        <span>Toplam</span>
                        <span>{order.totalAmount.toLocaleString("tr-TR")} ₺</span>
                    </div>

                </div>
            ))}
        </div>
    );
}
