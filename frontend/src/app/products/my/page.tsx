"use server";

import { getMyProductsServer } from "@/services/product/product.server";
import { ProductGrid } from "@/components/products/product-grid";
import AddProductButton from "@/components/products/add-product-button";

export default async function MyProductsPage() {
    const myProducts = await getMyProductsServer();

    return (
        <div className="container mx-auto py-8">
            <div className="flex items-center justify-between">
                <h1 className="text-2xl font-bold">Ürünlerim</h1>
                <AddProductButton />
            </div>

            <ProductGrid products={myProducts} showAddToCart={false} />
        </div>
    );
}
