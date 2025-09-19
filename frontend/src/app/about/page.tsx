export default function AboutPage() {
    return (
        <div className="py-8">
            <div className="max-w-6xl mx-auto">
                <h1 className="text-3xl font-bold text-gray-900 mb-6">Hakkımızda</h1>

                <div className="prose max-w-none">
                    <p className="text-lg text-gray-600 mb-6">
                        Test
                    </p>

                    <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-6 lg:gap-8 mt-8">
                        <div className="bg-white p-6 rounded-lg shadow-sm border">
                            <h2 className="text-xl font-semibold text-gray-900 mb-3">Misyonumuz</h2>
                            <p className="text-gray-600">
                                Test
                            </p>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow-sm border">
                            <h2 className="text-xl font-semibold text-gray-900 mb-3">Vizyonumuz</h2>
                            <p className="text-gray-600">
                                Test
                            </p>
                        </div>

                        <div className="bg-white p-6 rounded-lg shadow-sm border md:col-span-2 lg:col-span-1">
                            <h2 className="text-xl font-semibold text-gray-900 mb-3">Değerlerimiz</h2>
                            <p className="text-gray-600">
                                Test
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
