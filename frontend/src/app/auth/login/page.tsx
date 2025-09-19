"use server";

import {GuestOnly} from "@/components/auth/guest-only";
import LoginForm from "@/components/auth/login/login-form";

export default async function LoginPage({
                                            searchParams,
                                        }: {
    searchParams: Promise<{ message?: string }>;
}) {
    const params = await searchParams;
    const message = params?.message ?? null;

    return (
        <GuestOnly>
            <div className="mx-auto max-w-md py-10">
                <LoginForm successMessage={message}/>
            </div>
        </GuestOnly>
    );
}
