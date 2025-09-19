import { getSessionToken } from "@/lib/cookie.server";
import { AuthProvider } from "@/context/AuthContext";

export default async function Providers({ children }: { children: React.ReactNode }) {
    const token = await getSessionToken();
    return <AuthProvider initialAuth={!!token}>{children}</AuthProvider>;
}
