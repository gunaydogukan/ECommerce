"use client";

import { useState } from "react";
import type { Product } from "@/services/product/types";
import { ProductGrid } from "./product-grid";
import { Button } from "@/components/ui/button";

type Props = { products: Product[] };

const PAGE_SIZE = 6;

export default function MyProductsList({ products }: Props) {
    const [page, setPage] = useState(1);

    if (!products?.length) {
        return (
            <div className="border rounded-lg p-8 text-center text-gray-500">
                Henüz ürününüz yok.
            </div>
        );
    }

    const totalPages = Math.ceil(products.length / PAGE_SIZE);
    const start = (page - 1) * PAGE_SIZE;
    const currentProducts = products.slice(start, start + PAGE_SIZE);

    return (
        <div className="space-y-6">
            <ProductGrid products={currentProducts} showAddToCart={false} />

            {totalPages > 1 && (
                <div className="flex justify-center items-center gap-4">
                    <Button
                        variant="outline"
                        size="sm"
                        onClick={() => setPage((p) => Math.max(p - 1, 1))}
                        disabled={page === 1}
                    >
                        Önceki
                    </Button>
                    <span className="text-sm text-gray-600">
                        Sayfa {page} / {totalPages}
                    </span>
                    <Button
                        variant="outline"
                        size="sm"
                        onClick={() => setPage((p) => Math.min(p + 1, totalPages))}
                        disabled={page === totalPages}
                    >
                        Sonraki
                    </Button>
                </div>
            )}
        </div>
    );
}
