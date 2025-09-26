"use server"

import { getMyCartServer } from "@/services/cart/cart.server";
import { CartList } from "@/features/cart/cart-list";

export default async function CartPage() {
    const cart = await getMyCartServer();

    return (
        <div className="p-8">
            <h1 className="text-2xl font-bold mb-6">Sepetim</h1>
            <CartList items={cart} />
        </div>
    );
}
