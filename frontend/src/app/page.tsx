import { getProductsServer } from "@/services/product/product.server";
import { ProductGrid } from "@/components/products/product-grid";

export default async function HomePage() {
    const products = await getProductsServer();

    return (
        <main className="container mx-auto py-8">
            <ProductGrid products={products} />
        </main>
    );
}
