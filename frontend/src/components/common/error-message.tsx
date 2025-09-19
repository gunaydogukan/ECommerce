import { AlertCircle } from 'lucide-react';

interface ErrorMessageProps {
    message: string;
    onRetry?: () => void;
    className?: string;
}

export function ErrorMessage({ message, onRetry, className = '' }: ErrorMessageProps) {
    return (
        <div className={`text-center py-12 ${className}`}>
            <div className="flex flex-col items-center space-y-4">
                <AlertCircle className="h-12 w-12 text-red-500" />
                <p className="text-red-500 text-lg">{message}</p>
                {onRetry && (
                    <button
                        onClick={onRetry}
                        className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 transition-colors"
                    >
                        Tekrar Dene
                    </button>
                )}
            </div>
        </div>
    );
}
