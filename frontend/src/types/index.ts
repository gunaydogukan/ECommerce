export * from './product';

export interface ApiResponse<T> {
    data: T;
    message: string;
    success: boolean;
}

export const categories = [
    { id: 1, name: "Elektronik", slug: "elektronik" },
    { id: 2, name: "Moda", slug: "moda" },
    { id: 3, name: "Ev & Yaşam", slug: "ev-yasam" },
    { id: 4, name: "Kitap", slug: "kitap" },
    { id: 5, name: "Spor", slug: "spor" },
];
