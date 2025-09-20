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

export type CartApiResponse = ApiResponse<CartItem[]>;

export interface AddToCartPayload {
    productId: number;
    quantity: number;
}


export interface UpdateCartPayload {
    cartId: number;
    quantity: number;
}

export type UpdateCartApiResponse = ApiResponse<CartItem>;
export type AddToCartApiResponse = ApiResponse<CartItem>;
export type RemoveFromCartApiResponse = ApiResponse<string>;
