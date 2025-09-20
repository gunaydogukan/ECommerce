"use server";

import { getMeServer } from "@/services/user/user.server";
import ProfileCard from "@/components/user/profile-card";

export default async function ProfilePage() {
    const user = await getMeServer(); // fetch tamamen server-side

    return (
        <div className="mx-auto max-w-2xl px-4 md:px-0 py-10">
            {/* user verisini props olarak client component'e geçiriyoruz */}
            <ProfileCard user={user} />
        </div>
    );
}
