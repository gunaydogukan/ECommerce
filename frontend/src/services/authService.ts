import { api } from "@/lib/api";
import { API_ENDPOINTS } from "@/lib/constants";

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

export async function login(payload: LoginPayload): Promise<LoginResponse> {
  const res = await api.post(`${API_ENDPOINTS.AUTH}/auth/login`, payload);

    const data = res.data.data;
    const { token, ...user } = data;

  if (!token) {
    throw new Error("Giriş başarısız: Token alınamadı.");
  }

  if (typeof window !== "undefined") {
    localStorage.setItem("token", token);
  }

  return { token, user };
}

export async function register(payload: RegisterPayload): Promise<RegisterResponse> {
  const res = await api.post(`${API_ENDPOINTS.AUTH}/auth/register`, payload);

  const data = res.data.data;

  return data;
}

export function logout() {
  if (typeof window !== "undefined") {
    localStorage.removeItem("token");
  }
}

export function getAuthStatus(): boolean {
  if (typeof window === "undefined") return false;
  return !!localStorage.getItem("token");
}
