"use client";

import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import {categories} from "@/types";

interface CategorySelectProps {
    name?: string;
    defaultValue?: number;
    value?: number;
    onChange?: (value: number) => void;
    required?: boolean;
}


export function CategorySelect({ name = "categoryId", defaultValue, value, onChange, required }: CategorySelectProps) {
    return (
        <Select
            defaultValue={defaultValue?.toString()}
            value={value?.toString()}
            onValueChange={(val) => onChange?.(Number(val))}
            name={name}
            required={required}
        >
            <SelectTrigger className="w-full">
                <SelectValue placeholder="Kategori seçiniz" />
            </SelectTrigger>
            <SelectContent>
                {categories.map((cat) => (
                    <SelectItem key={cat.id} value={cat.id.toString()}>
                        {cat.name}
                    </SelectItem>
                ))}
            </SelectContent>
        </Select>
    );
}
