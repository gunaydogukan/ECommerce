export const BASE_URL = process.env.NEXT_PUBLIC_API_URL || `http://localhost:5021/api`  ;

if (!BASE_URL) {
    throw new Error("API_URL ENV DOSYASINDA BULUNAMADI");
}
