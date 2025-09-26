"use server";

import { getMyOrdersServer } from "@/services/order/order.server";
import OrdersList from "@/features/orders/orders-list";

export default async function MyOrdersPage() {
    const orders = await getMyOrdersServer();

    return (
        <div className="p-8">
            <h1 className="text-2xl font-bold mb-6">Siparişlerim</h1>
            <OrdersList orders={orders.data} />
        </div>
    );
}
