import { ApiResponse } from "@/types/index";

export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    imageUrl?: string;
}

export interface ProductsResponse {
    data: Product[];
    total: number;
    page: number;
    limit: number;
}

export type ProductResponse = ApiResponse<ProductsResponse>;
