export function ProductSkeleton() {
    return (
        <div className="flex flex-col overflow-hidden rounded-xl border animate-pulse">
            <div className="h-48 w-full bg-gray-200" />
            <div className="p-4 flex-1">
                <div className="h-6 bg-gray-200 rounded mb-2" />
                <div className="h-4 bg-gray-200 rounded w-3/4" />
            </div>
            <div className="flex items-center justify-between p-4">
                <div className="h-6 bg-gray-200 rounded w-20" />
                <div className="h-8 bg-gray-200 rounded w-24" />
            </div>
        </div>
    );
}
