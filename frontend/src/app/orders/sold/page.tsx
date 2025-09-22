"use server";

import { getSoldProductsServer } from "@/services/order/order.server";
import SoldProductsList from "@/components/orders/sold-products-list";

export default async function SoldProductsPage() {
    const products = await getSoldProductsServer();

    return (
        <div className="p-8">
            <h1 className="text-2xl font-bold mb-6">Satılan Ürünlerim</h1>
            <SoldProductsList products={products.data} />
        </div>
    );
}
