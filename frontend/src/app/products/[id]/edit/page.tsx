"use server"

import { getProductByIdServer } from "@/services/product/product.server";
import EditProductForm from "@/components/products/edit/ edit-product-form";

interface EditProductPageProps {
    params: { id: string };
}

export default async function EditProductPage({ params }: EditProductPageProps) {
    const productId = Number(params.id);
    const product = await getProductByIdServer(productId);

    if (!product) {
        return <div className="p-6 text-center">Ürün bulunamadı.</div>;
    }

    return (
        <div className="mx-auto max-w-2xl py-10">
            <h1 className="text-2xl font-bold mb-6">Ürün Düzenle</h1>
            <EditProductForm product={product} />
        </div>
    );
}
