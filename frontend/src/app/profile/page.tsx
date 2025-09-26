"use server";

import { getMeServer } from "@/services/user/user.server";
import ProfileCard from "@/features/user/profile-card";

export default async function ProfilePage() {
    const user = await getMeServer();

    return (
        <div className="mx-auto max-w-4xl px-4 md:px-0 py-10">
            <ProfileCard user={user} />
        </div>
    );
}
