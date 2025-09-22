export const ROUTES = {
    HOME: '/',
    PRODUCTS: '/products',
    ABOUT: '/about',
    CONTACT: '/contact',
    LOGIN: '/auth/login',
    REGISTER: '/auth/register',
    PROFILE: '/profile',
    CART: "/cart",
    ORDERS: "/orders/my",
} as const;

export const API_ENDPOINTS = {
    PRODUCTS: '/products',
    AUTH: '/auth',
    USERS: '/users',
    CART: "/cart",
    ORDERS: "/orders"
} as const;

export const PLACEHOLDER_IMAGE = "https://placehold.co/400x300?text=No+Image&font=roboto";
