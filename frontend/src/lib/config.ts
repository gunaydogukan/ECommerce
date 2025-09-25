export const BASE_URL = process.env.NEXT_PUBLIC_API_URL || `https://localhost:7260/api`  ;

if (!BASE_URL) {
    throw new Error("API_URL ENV DOSYASINDA BULUNAMADI");
}
