import { Mail, Phone, MapPin } from 'lucide-react';

export default function ContactPage() {
    return (
        <div className="py-8">
            <div className="max-w-6xl mx-auto">
                <h1 className="text-3xl font-bold text-gray-900 mb-6">İletişim</h1>

                <div className="grid lg:grid-cols-2 gap-8 lg:gap-12">
                    <div>
                        <h2 className="text-xl font-semibold text-gray-900 mb-4">Bizimle İletişime Geçin</h2>
                        <p className="text-gray-600 mb-6">
                            Test
                        </p>

                        <div className="space-y-4">
                            <div className="flex items-center space-x-3">
                                <Mail className="h-5 w-5 text-blue-600" />
                                <span className="text-gray-700">info@apptotech.com</span>
                            </div>

                            <div className="flex items-center space-x-3">
                                <Phone className="h-5 w-5 text-blue-600" />
                                <span className="text-gray-700">+90 (000) 00 00 00</span>
                            </div>

                            <div className="flex items-center space-x-3">
                                <MapPin className="h-5 w-5 text-blue-600" />
                                <span className="text-gray-700">İstanbul, Türkiye</span>
                            </div>
                        </div>
                    </div>

                    <div className="bg-white p-6 lg:p-8 rounded-lg shadow-sm border">
                        <h3 className="text-lg font-semibold text-gray-900 mb-4">İletişim Formu</h3>
                        <form className="space-y-4">
                            <div>
                                <label htmlFor="name" className="block text-sm font-medium text-gray-700 mb-1">
                                    Ad Soyad
                                </label>
                                <input
                                    type="text"
                                    id="name"
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="Adınızı ve soyadınızı girin"
                                />
                            </div>

                            <div>
                                <label htmlFor="email" className="block text-sm font-medium text-gray-700 mb-1">
                                    E-posta
                                </label>
                                <input
                                    type="email"
                                    id="email"
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="E-posta adresinizi girin"
                                />
                            </div>

                            <div>
                                <label htmlFor="message" className="block text-sm font-medium text-gray-700 mb-1">
                                    Mesaj
                                </label>
                                <textarea
                                    id="message"
                                    rows={4}
                                    className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                                    placeholder="Mesajınızı yazın"
                                />
                            </div>

                            <button
                                type="submit"
                                className="w-full bg-blue-600 text-white py-2 px-4 rounded-md hover:bg-blue-700 transition-colors"
                            >
                                Gönder
                            </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}
