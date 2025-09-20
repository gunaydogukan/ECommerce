import { getMyCartServer } from "@/services/cart/cart.server";
import { CartList } from "@/components/cart/cart-list";

export default async function CartPage() {
    const cart = await getMyCartServer(); // server-side fetch

    return (
        <div className="p-8">
            <h1 className="text-2xl font-bold mb-6">Sepetim</h1>
            <CartList items={cart} />
        </div>
    );
}
