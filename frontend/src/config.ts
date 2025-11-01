const config = {
  apiKey: import.meta.env.VITE_REACT_APP_API_KEY,
  apiBaseUrl: 'https://financialmodelingprep.com/stable',
  backendUrl: import.meta.env.VITE_BACKEND_URL,
} as const;

export default config;
