"use client";

import { useState, FormEvent } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { updateProductServer } from "@/services/product/product.server";
import { Product } from "@/services/product/types";
import { useRouter } from "next/navigation";
import {CategorySelect} from "@/components/common/category-select";

interface EditProductFormProps {
    product: Product;
    onSuccess?: () => void;
}

export default function EditProductForm({ product, onSuccess }: EditProductFormProps) {
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);
    const router = useRouter();

    async function handleSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        setLoading(true);
        setError(null);

        const formData = new FormData(e.currentTarget);

        const payload = {
            name: String(formData.get("name")),
            description: String(formData.get("description") || ""),
            price: Number(formData.get("price")),
            categoryId: Number(formData.get("categoryId")),
        };

        try {
            await updateProductServer(product.id, payload);
            router.push("/products/my");
            onSuccess?.();
        } catch (err: any) {
            setError(err.message);
        } finally {
            setLoading(false);
        }
    }

    return (
        <form onSubmit={handleSubmit} className="space-y-4">
            <Input name="name" defaultValue={product.name} required />
            <Textarea name="description" defaultValue={product.description || ""} />
            <Input type="number" name="price" defaultValue={product.price} required />

            <CategorySelect defaultValue={product.categoryId} required />

            <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Güncelleniyor..." : "Kaydet"}
            </Button>

            {error && <p className="text-sm text-red-600">{error}</p>}
        </form>
    );
}
