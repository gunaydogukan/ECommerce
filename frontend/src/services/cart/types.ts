import { ApiResponse } from "@/types/index";

export interface CartItem {
    id: number;
    userId: number;
    productId: number;
    productName: string;
    unitPrice: number;
    quantity: number;
    subtotal: number;
}

export interface AddToCartPayload {
    productId: number;
    quantity: number;
}

export interface AddToCartApiResponse {
    data: CartItem;
    message?: string;
}

export type CartApiResponse = ApiResponse<CartItem[]>;

