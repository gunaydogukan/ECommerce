"use client";

import { useRouter } from "next/navigation";
import { Button } from "@/components/ui/button";

export default function AddProductButton() {
    const router = useRouter();

    return (
        <Button onClick={() => router.push("/products/add")}>
            Yeni Ürün Ekle
        </Button>
    );
}
