import { Product } from "@/services/product/types";
import { ProductCard } from "./product-card";

interface ProductGridProps {
    products: Product[];
    showAddToCart?: boolean;
}

export function ProductGrid({ products, showAddToCart = true }: ProductGridProps) {
    if (!products || products.length === 0) {
        return (
            <div className="text-center py-12">
                <p className="text-gray-500 text-lg">Henüz ürün bulunmamaktadır.</p>
            </div>
        );
    }

    return (
        <div className="grid gap-4 md:gap-6 grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 3xl:grid-cols-6">
            {products.map((product) => (
                <ProductCard key={product.id} product={product} showAddToCart={showAddToCart} />
            ))}
        </div>
    );
}
