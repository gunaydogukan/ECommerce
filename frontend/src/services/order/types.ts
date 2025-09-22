import { ApiResponse } from "@/types/index";
import { Product } from "@/services/product/types";

export interface CreateOrderPayload {
    items: {
        productId: number;
        quantity: number;
    }[];
}

export interface OrderItemResponse {
    productId: number;
    productName: string;
    quantity: number;
    unitPrice: number;
    subtotal: number;
}

export interface OrderResponse {
    id: number;
    userId: number;
    status: string;
    totalAmount: number;
    createdAt: string;
    updatedAt: string;
    orderItems: OrderItemResponse[];
}

export type CreateOrderApiResponse = ApiResponse<OrderResponse>;
export type GetMyOrdersApiResponse = ApiResponse<OrderResponse[]>;

