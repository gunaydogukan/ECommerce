"use client";

import { useEffect, useState } from "react";
import { getMeClient } from "@/services/user/user.client";
import { UserProfile } from "@/services/user/types";

export function useUserProfile() {
    const [user, setUser] = useState<UserProfile | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        getMeClient()
            .then((data) => {
                setUser(data);
                setError(null);
            })
            .catch((err) => {
                setError(err.message);
                setUser(null);
            })
            .finally(() => setLoading(false));
    }, []);

    return { user, loading, error };
}
