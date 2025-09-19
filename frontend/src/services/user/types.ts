import { ApiResponse } from "@/types";

export interface UserProfile {
    email: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
}

export type GetMeApiResponse = ApiResponse<UserProfile>;
