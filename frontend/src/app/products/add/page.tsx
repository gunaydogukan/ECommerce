import AddProductForm from "@/components/products/add-product-form";

export default function AddProductPage() {
    return (
        <div className="max-w-2xl mx-auto py-10 px-4">
            <h1 className="text-2xl font-bold mb-6">Yeni Ürün Ekle</h1>
            <AddProductForm />
        </div>
    );
}
