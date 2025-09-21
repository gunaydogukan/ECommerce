"use server";

import { getProductsServer } from "@/services/product/product.server";
import { ProductGrid } from "@/components/products/list/product-grid";

// export const revalidate = 60; // 60 sn'de bir yeniden oluştur

export default async function ProductsPage() {
    const products = await getProductsServer();

    return (
        <main className="container mx-auto py-8">
            <ProductGrid products={products} />
        </main>
    );
}
