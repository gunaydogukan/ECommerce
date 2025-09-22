"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import { Card, CardContent, CardFooter, CardHeader } from "@/components/ui/card";
import { Product } from "@/services/product/types";
import { AddToCartButton } from "./add/add-to-cart-button";
import { PLACEHOLDER_IMAGE } from "@/lib/constants";
import { Pencil, Trash2 } from "lucide-react";
import { Button } from "@/components/ui/button";
import { deleteProductServer } from "@/services/product/product.server";
import { useState } from "react";
import {BuyNowButton} from "@/components/products/buy-now-button";
import {AddToFavoriteButton} from "@/components/products/add/add-to-favorite-button";

interface ProductCardProps {
    product: Product;
    showAddToCart?: boolean;
    canEdit?: boolean;
}

export function ProductCard({ product, showAddToCart = true, canEdit = false }: ProductCardProps) {
    const router = useRouter();
    const [loading, setLoading] = useState(false);

    async function handleDelete() {
        if (!confirm("Bu ürünü silmek istediğinize emin misiniz?")) return;

        try {
            setLoading(true);
            console.log("asdasdasasdasdasa"+product.id);
            await deleteProductServer(product.id);
            router.refresh();
        } catch (err: any) {
            alert(err.message);
        } finally {
            setLoading(false);
        }
    }

    return (
        <Card className="flex flex-col overflow-hidden">
            <CardHeader className="p-0 relative">
                <img
                    src={product.imageUrl || PLACEHOLDER_IMAGE}
                    alt={product.name}
                    className="h-48 w-full object-cover"
                />
                <div className="absolute top-2 right-2">
                    <AddToFavoriteButton productId={product.id} />
                </div>
            </CardHeader>

            <CardContent className="p-4 flex-1">
                <h3 className="text-lg font-semibold truncate">{product.name}</h3>
                <p className="mt-1 text-sm text-gray-600 truncate">
                    {product.description || "Açıklama Yok"}
                </p>
            </CardContent>

            <CardFooter className="flex items-center justify-between p-4">
                <span className="text-lg font-bold black">
                    {product.price.toLocaleString("tr-TR")} ₺
                </span>

                <div className="flex items-center gap-2">
                    <div className="flex items-center gap-1">
                        {showAddToCart && (
                            <div className="flex gap-2">
                                <AddToCartButton productId={product.id} />
                                <BuyNowButton productId={product.id} />
                            </div>
                        )}
                    </div>
                    {canEdit && (
                        <>
                            <Link href={`/products/${product.id}/edit`}>
                                <Button
                                    variant="outline"
                                    size="sm"
                                    className="flex items-center gap-1 text-gray-600 hover:text-blue-600"
                                >
                                    <Pencil className="h-4 w-4" />
                                    Düzenle
                                </Button>
                            </Link>
                            <Button
                                variant="destructive"
                                size="sm"
                                onClick={handleDelete}
                                disabled={loading}
                                className="flex items-center gap-1"
                            >
                                <Trash2 className="h-4 w-4" />
                                {loading ? "Siliniyor..." : "Sil"}
                            </Button>
                        </>
                    )}
                </div>
            </CardFooter>
        </Card>
    );
}
