export * from './product';

export interface ApiResponse<T> {
    data: T;
    message: string;
    success: boolean;
}
