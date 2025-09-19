import { ApiResponse } from "@/types/index";

export interface LoginPayload {
    email: string;
    password: string;
}

export interface RegisterPayload {
    email: string;
    firstName: string;
    lastName: string;
    password: string;
    phoneNumber: string;
}

export interface LoginResponse {
    token: string;
    user: {
        userId: number;
        email: string;
        fullName: string;
    };
}

export interface RegisterResponse {
    email: string;
    fullName: string;
    phoneNumber: string;
}

export type LoginApiResponse = ApiResponse<LoginResponse>;
export type RegisterApiResponse = ApiResponse<RegisterResponse>;
