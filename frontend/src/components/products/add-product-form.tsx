"use client";

import { FormEvent } from "react";
import { useAddProduct } from "@/hooks/use-add-product";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Textarea } from "@/components/ui/textarea";
import { useRouter } from "next/navigation";

export default function AddProductForm() {
    const { addProduct, loading, error } = useAddProduct();
    const router = useRouter();

    async function handleSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const form = e.currentTarget;
        const formData = new FormData(form);

        const payload = {
            categoryId: Number(formData.get("categoryId")),
            name: String(formData.get("name")),
            description: String(formData.get("description") || ""),
            price: Number(formData.get("price")),
        };

        const created = await addProduct(payload);
        if (created) {
            form.reset();
            router.push("/products/my");
        }
    }

    return (
        <form onSubmit={handleSubmit} className="space-y-4">
            <Input name="name" placeholder="Ürün adı" required />
            <Textarea name="description" placeholder="Açıklama" />
            <Input type="number" name="price" placeholder="Fiyat" required />
            <Input type="number" name="categoryId" placeholder="Kategori ID" required />

            <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Ekleniyor..." : "Ürün Ekle"}
            </Button>

            {error && <p className="text-sm text-red-600">{error}</p>}
        </form>
    );
}
