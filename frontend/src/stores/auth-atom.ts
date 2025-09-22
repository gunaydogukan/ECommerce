"use client";

import { atom } from "jotai";
import { UserProfile } from "@/services/user/types";

export const isAuthenticatedAtom = atom(false);
