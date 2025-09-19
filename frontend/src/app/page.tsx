"use client";

import { useProducts } from "@/hooks/use-products";
import { ProductGrid } from "@/components/products/product-grid";
import { ErrorMessage } from "@/components/common/error-message";

export default function HomePage() {
    const { products, loading, error, refetch } = useProducts();

    if (error) {
        return (
            <ErrorMessage 
                message={error}
                onRetry={refetch}
            />
        );
    }

    return (
        <div>
            <ProductGrid products={products} loading={loading} />
        </div>
    );
}
