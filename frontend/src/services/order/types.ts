import { ApiResponse } from "@/types/index";

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

export interface SoldProductSale {
    orderId: number;
    buyerId: number;
    buyerEmail: string;
    quantity: number;
    unitPrice: number;
    subtotal: number;
}

export interface SoldProductResponse {
    productId: number;
    productName: string;
    totalQuantity: number;
    totalRevenue: number;
    sales: SoldProductSale[];
}

export type CreateOrderApiResponse = ApiResponse<OrderResponse>;
export type GetMyOrdersApiResponse = ApiResponse<OrderResponse[]>;
export type GetSoldProductsApiResponse = ApiResponse<SoldProductResponse[]>;

