import { ApiResponse } from "@/types/index";

export interface Product {
    id: number;
    name: string;
    description: string;
    categoryId: number;
    price: number;
    imageUrl?: string;
    userId: number;
    createdAt?: string;
    updatedAt?: string;
}

export interface AddProductRequest {
    categoryId: number;
    name: string;
    description?: string;
    price: number;
}

export interface ProductsResponse extends ApiResponse<Product[]> {}

export interface ProductResponse extends ApiResponse<Product> {}
