"use client";

import { useState } from "react";
import { addProductServer } from "@/services/product/product.server";
import type { AddProductRequest, Product } from "@/services/product/types";

interface UseAddProductResult {
    loading: boolean;
    error: string | null;
    success: string | null;
    addProduct: (payload: AddProductRequest) => Promise<Product | null>;
}

export function useAddProduct(): UseAddProductResult {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const [success, setSuccess] = useState<string | null>(null);

    async function addProduct(payload: AddProductRequest): Promise<Product | null> {
        setLoading(true);
        setError(null);
        setSuccess(null);

        try {
            const product = await addProductServer(payload);
            setSuccess("Ürün başarıyla eklendi 🎉");
            return product;
        } catch (err: any) {
            setError(err.message || "Ürün eklenemedi");
            return null;
        } finally {
            setLoading(false);
        }
    }

    return { loading, error, success, addProduct };
}
