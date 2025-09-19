"use server";

import { GuestOnly } from "@/components/auth/guest-only";
import RegisterForm from "@/components/auth/register/register-form";

export default async function RegisterPage() {
    return (
        <GuestOnly>
            <div className="mx-auto max-w-md py-10">
                <RegisterForm />
            </div>
        </GuestOnly>
    );
}
