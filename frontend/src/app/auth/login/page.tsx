"use server";

import {GuestOnly} from "@/components/auth/guest-only";
import LoginForm from "@/components/auth/login/login-form";

export default async function LoginPage() {
    return (
        <GuestOnly>
            <div className="mx-auto max-w-md py-10">
                <LoginForm />
            </div>
        </GuestOnly>
    );
}