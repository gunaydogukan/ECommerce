export interface FavoriteResponse {
    id: number;
    productId: number;
    userId: number;
    product?: {
        id: number;
        name: string;
        price: number;
        imageUrl?: string;
    };
}

export interface MyFavoriteResponse {
    id: number;
    productId: number;
    productName: string;
    price: number;
}

export interface AddFavoriteRequest {
    productId: number;
}
