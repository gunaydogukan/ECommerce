"use server";

import ProfileCard from "@/components/user/profile-card";

export default async function ProfilePage() {
    return (
        <div className="mx-auto max-w-2xl px-4 md:px-0 py-10">
            <ProfileCard />
        </div>
    );
}
