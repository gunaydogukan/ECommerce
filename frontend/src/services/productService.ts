import { api } from "@/lib/api";
import { Product, ProductsResponse } from "@/types/product";
import { API_ENDPOINTS } from "@/lib/constants";

export const getProducts = async (): Promise<Product[]> => {
    const response = await api.get<ProductsResponse>(API_ENDPOINTS.PRODUCTS);
    return response.data.data;
};

export const getProduct = async (id: number): Promise<Product> => {
    const response = await api.get<{ data: Product }>(`${API_ENDPOINTS.PRODUCTS}/${id}`);
    return response.data.data;
};
